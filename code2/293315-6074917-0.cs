    XmlTextReader xml;
                            WebRequest web;
    
                            web = WebRequest.Create(xmlurl);
                            if(Convert.ToBoolean(ConfigurationManager.AppSettings["behindproxy"].ToString()))
                            {
                                WebProxy prxy = new WebProxy();
                                Uri prxyUri = new Uri("http://xxx:8080");
    
                                prxy.Address = prxyUri;
                                prxy.BypassProxyOnLocal = true;
                                prxy.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["proxyusername"].ToString(), ConfigurationManager.AppSettings["proxypassword"].ToString());
                                web.Proxy = prxy;
                            }
    
                            var response = web.GetResponse().ToString();
                            xml = new XmlTextReader(response);
