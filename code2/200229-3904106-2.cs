                {
                  var proxy = new DevicesServiceClient("BasicHttpBinding_IDevicesService");
                  BasicHttpBinding binding = new                                                 BasicHttpBinding("BasicHttpBinding_IDevicesService");
                  var proxySettings = ApplicationDetails.CheckProxySettings();
                    Uri domainAddress;
                    var strtemp = new string[] { };
                    //WebProxy webproxy = new WebProxy();
                    var networkCredentials = new NetworkCredential();
                    if (proxySettings.ProxyServerType == "http")
                    {
                        domainAddress = new Uri(string.Format("http://{0}:{1}", proxySettings.ProxyServerAddress, proxySettings.ProxyServerPort));
                    }
                    else if (proxySettings.ProxyServerType == "https")
                    {
                        domainAddress = new Uri(string.Format("https://{0}:{1}", proxySettings.ProxyServerAddress, proxySettings.ProxyServerPort));
                    }
                    else
                    {
                        domainAddress = new Uri(string.Format("http://{0}:{1}", proxySettings.ProxyServerAddress, proxySettings.ProxyServerPort));
                    }
                    //
                    WebProxy webproxy = new WebProxy(domainAddress.ToString(), true, strtemp);
                    //
                    //networkCredentials.Domain = domainAddress.ToString();
                    if (proxySettings.ProxyAuthentication == "1")
                    {
                        networkCredentials.UserName = proxySettings.Username;
                        networkCredentials.Password = proxySettings.Password;
                    }
                    webproxy.Credentials = networkCredentials;
                    webproxy.BypassProxyOnLocal = false;
                    WebRequest.DefaultWebProxy = webproxy;
                    binding.UseDefaultWebProxy = true;
                    proxy.Endpoint.Binding = binding;
                }
