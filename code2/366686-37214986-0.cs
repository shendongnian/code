    using (FileStream src = System.IO.File.Open(@"C:\XML\OrderXML.txt", FileMode.Open))
                {
                    src.CopyTo(ms);
                }
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "text/xml";
                    wc.Headers[HttpRequestHeader.AcceptEncoding] = "Encoding.UTF8";
                    //wc.Headers[HttpRequestHeader.ContentLength] = ms.Length.ToString();                    
                    wc.UploadString(sURL, ms.ToString());
                }
