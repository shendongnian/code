            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;
            var sp = ServicePointManager.FindServicePoint(endpoint);
            sp.ConnectionLeaseTimeout = (int)Parameters.ConnectionLeaseTimeout.TotalMilliseconds;
            string source = "";
            using (var handler = new HttpClientHandler())
            {
                handler.UseCookies = usecookies;
                WebProxy wp = new WebProxy(SelectedProxy.Address);
                handler.Proxy = wp;
                
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = Parameters.WcTimeout;
                    int n = 0;
                    back:
                    using (var request = new HttpRequestMessage(new HttpMethod(HttpMethod), endpoint))
                    {
                        if (headers != null)
                        {
                            foreach (var h in headers)
                            {
                                request.Headers.TryAddWithoutValidation(h.Item1, h.Item2);
                            }
                        }
                        if (content != "")
                        {
                            request.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
                        }
                        HttpResponseMessage response = new HttpResponseMessage();
                        try
                        {
                            response = await client.SendAsync(request);
                        }
                        catch (Exception e)
                        {
                            if(e.InnerException != null)
                            {
                                if(e.InnerException.InnerException != null)
                                {
                                    if (e.InnerException.InnerException.Message.Contains("A connection attempt failed because the connected party did not properly respond after"))
                                    {
                                        if (n <= Parameters.TCPMaxTries)
                                        {
                                            n++;
                                            goto back;
                                        }
                                    }
                                }
                            }
                            // Manage here other exceptions
                        }
                        source = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return source;
