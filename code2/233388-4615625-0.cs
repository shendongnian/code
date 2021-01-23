    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace WebGet
    {
        class progMain
        {
            static void Main(string[] args)
            {
                ASCIIEncoding asc = new ASCIIEncoding();
                WebRequest wrq = WebRequest.Create("http://localhost");
    
                WebResponse wrp = wrq.GetResponse();
                byte [] responseBuf = new byte[wrp.ContentLength];
    
                int status = wrp.GetResponseStream().Read(responseBuf, 0, responseBuf.Length);
                Console.WriteLine(asc.GetString(responseBuf));
            }
        }
    }
