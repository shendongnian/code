    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Web;
    using System.Net;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                CookieContainer cookieContainer = new CookieContainer();
                HttpWebRequest wpost = (HttpWebRequest) HttpWebRequest.Create("http://www.bikeforums.net/login.php?do=login");
                wpost.CookieContainer = cookieContainer;
                wpost.Method = "POST";
                string postData = "do=login&vb_login_md5password=d93bd4ce1af6a9deccaf0ea844d6c05d&vb_login_md5password_utf=d93bd4ce1af6a9deccaf0ea844d6c05d&s=&securitytoken=guest&url=%2Fmember.php%2F227664-StackOverflow&vb_login_username=StackOverflow&vb_login_password=";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                wpost.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                wpost.ContentLength = byteArray.Length;
                // Get the request stream.
                System.IO.Stream dataStream = wpost.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                HttpWebResponse response = (HttpWebResponse) wpost.GetResponse();
                
                // Request 
                wpost = (HttpWebRequest)WebRequest.Create("http://www.bikeforums.net/member.php/227664-StackOverflow");
    
                //Assing the cookies created on the server to the new request
                wpost.CookieContainer = cookieContainer;
                wpost.Method = "GET";
                 response = (HttpWebResponse)wpost.GetResponse();
    
                 Stream receiveStream = response.GetResponseStream();
                 // Pipes the stream to a higher level stream reader with the required encoding format. 
                 StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //Display the result to console...
                 Console.WriteLine(readStream.ReadToEnd());
                 response.Close();
                 readStream.Close();
    
                Console.Read();
                
            }
        }
    }
    
