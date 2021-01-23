            var webRequest = (HttpWebRequest) WebRequest.Create(url);
            webRequest.Headers.GetType().InvokeMember("ChangeInternal",
                                                          BindingFlags.Instance | BindingFlags.NonPublic |
                                                          BindingFlags.InvokeMethod, Type.DefaultBinder,
                                                          webRequest.Headers,
                                                          new object[] {name, value});
