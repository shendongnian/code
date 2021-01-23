    private void GetPage(string protocol, string address, string extraPath, string[][] postData)
    {
          try
          {
               long length = 0;
               string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
                HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(protocol + address + extraPath);
                httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;
                httpWebRequest2.Method = "POST";
                httpWebRequest2.KeepAlive = true;
                httpWebRequest2.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                httpWebRequest2.Host = address;
                httpWebRequest2.Referer = protocol + address;
                httpWebRequest2.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.30 (KHTML, like Gecko) Chrome/12.0.742.112 Safari/534.30";
                httpWebRequest2.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                httpWebRequest2.Headers.Add(HttpRequestHeader.AcceptLanguage, "pt-BR,pt;q=0.8,en-US;q=0.6,en;q=0.4,pt-PT;q=0.2,en-GB;q=0.2");
                httpWebRequest2.Credentials = System.Net.CredentialCache.DefaultCredentials;
                Stream memStream = new System.IO.MemoryStream();
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes(boundary + "\r\n");
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                length += boundarybytes.Length;
                boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                length += boundarybytes.Length;
                // Send any data via POST that you might need
                for (int i = 0; i < postData.length; i++;
                {
                     string head = "Content-Disposition: form-data; name=\"" + postData[i][0] + "\"\r\n\r\n";
                     byte[] headbytes = System.Text.Encoding.ASCII.GetBytes(head);
                     memStream.Write(headbytes, 0, headbytes.Length);
                     length += headbytes.Length;
                     head = postData[i][1];
                     headbytes = System.Text.Encoding.ASCII.GetBytes(head);
                     memStream.Write(headbytes, 0, headbytes.Length);
                     length += headbytes.Length;
                     memStream.Write(boundarybytes, 0, boundarybytes.Length);
                     length += boundarybytes.Length;
                }
                httpWebRequest2.ContentLength = memStream.Length;
                Stream requestStream = httpWebRequest2.GetRequestStream();
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();
                WebResponse webResponse2 = httpWebRequest2.GetResponse();
                Stream stream2 = webResponse2.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2, Encoding.UTF8);
                string htmlpage = reader2.ReadToEnd();
                reader2.Close();
                webResponse2.Close();
                httpWebRequest2 = null;
                webResponse2 = null;
                // At this point, htmlpage contains all the code from the page ready to be handled
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        // Got an error page from the server so save it and show it on browser
                        Stream stream2 = response.GetResponseStream();
                        StreamReader reader2 = new StreamReader(stream2, Encoding.UTF7);
                        StreamWriter writer = new StreamWriter("error.html");
                        writer.Write(reader2.ReadToEnd());
                        writer.Close();
                        reader2.Close();
                        response.Close();
                        response = null;
                        System.Diagnostics.Process.Start("error.html");
                    }
                }
            }
        }
