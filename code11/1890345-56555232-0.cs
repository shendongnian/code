    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        WebProxy proxy = new WebProxy("proxy.xyz.local", 81) { UseDefaultCredentials = true };
                        WebRequest request = WebRequest.Create(globaConfigStatciValues.Url);
                        request.Proxy = proxy;
                        request.Method = "GET";
                        request.Credentials = new NetworkCredential(globaConfigStatciValues.userName,
                            globaConfigStatciValues.Password);
        
        
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                            try
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    isConnectionSucessfull = true;
                                    tracing.Trace($" Resposne is correct  {response.StatusCode}");
                                    TracingMessage += $"Resposne is correct  {response.StatusCode} \n";
                                }
                                else
                                {
                                    TracingMessage += $"Response from connecting to API {response.StatusCode} \n";
                                    tracing.Trace($"Response from connecting to API {response.StatusCode}");
                                }
        
                            }
                            catch (Exception e)
                            {
                                TracingMessage += $" In catch block {e} \n";
                                tracing.Trace($" In catch block {e}");
                                createLogRecord( e.StackTrace,TracingMessage);
                               // throw new Exception($"There was an issue with connecting to API {e.Message}");
                            }
                        }
