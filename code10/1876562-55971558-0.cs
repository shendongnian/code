    try
                        {
                            sslStream.AuthenticateAsClient(hostName, certificates, SslProtocols.Tls12, true);
    
                            byte[] buffer = new byte[5120];
                            int bytes;
                            var pqr = string.Format("GET {0}  HTTP/1.1\r\nHost: {1}\r\n\r\n", url, "mytestapp.azurewebsites.net");
                            byte[] request = Encoding.UTF8.GetBytes(pqr);
                            sslStream.Write(request, 0, request.Length);
                            var ppp =  ReadStream(sslStream);
                            sslStream.Flush();
    
                        }
                        catch (AuthenticationException e)
                        {
                            Console.WriteLine("Exception: {0}", e.Message);
                            if (e.InnerException != null)
                            {
                                Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                            }
                            Console.WriteLine("Authentication failed - closing the connection.");
                            client.Close();
                            return;
                        }
     private static string ReadStream(Stream stream)
            {
                byte[] resultBuffer = new byte[2048];
                string value = "";
                //requestStream.BeginRead(resultBuffer, 0, resultBuffer.Length, new AsyncCallback(ReadAsyncCallback), new result() { buffer = resultBuffer, stream = requestStream, handler = callback, asyncResult = null });
                do
                {
                    try
                    {
                        int read = stream.Read(resultBuffer, 0, resultBuffer.Length);
                        value += Encoding.UTF8.GetString(resultBuffer, 0, read);
    
                        if (read < resultBuffer.Length)
                            break;
                    }
                    catch { break; }
                } while (true);
                return value;
            }
