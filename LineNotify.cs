using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TestLine.Request
{
    public class LineNotify
    {
        public HttpWebResponse LineNotify(string message, string Linetoken)
        {
            HttpWebRequest httpwebrequest = WebRequest.Create("https://notify-api.line.me/api/notify") as HttpWebRequest;
            httpwebrequest.KeepAlive = true;
            httpwebrequest.ContentType = "application/x-www-form-urlencoded";
            httpwebrequest.AllowAutoRedirect = true;
            httpwebrequest.Referer = "https://notify-api.line.me";
            httpwebrequest.Host = "notify-api.line.me";
            httpwebrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            httpwebrequest.Accept = "application/json, text/javascript, */*; q=0.01";
            httpwebrequest.CookieContainer = new CookieContainer();      
            httpwebrequest.Method = "POST";
         
            httpwebrequest.Headers["Authorization"] = "Bearer "+ Linetoken + "";

            string postdata = "message="+ message;
            bool issupport = httpwebrequest.SupportsCookieContainer;
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postdata);
            httpwebrequest.ContentLength = dataBytes.Length;
            using (Stream postStream3 = httpwebrequest.GetRequestStream())
            {
                postStream3.Write(dataBytes, 0, dataBytes.Length);
            }
            HttpWebResponse httpResponse = httpwebrequest.GetResponse() as HttpWebResponse;
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
             //Do something 
               
            }
            else
            {
            // Do somthing
            }
            return httpResponse;
    }
    }
}