    System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                    webRequest.AllowWriteStreamBuffering = true;
                    webRequest.Timeout = 30000;
                    webRequest.ServicePoint.ConnectionLeaseTimeout = 5000;
                    webRequest.ServicePoint.MaxIdleTime = 5000;
    
                    using (System.Net.WebResponse webResponse = webRequest.GetResponse())
                    {
    
                        using (System.IO.Stream stream = webResponse.GetResponseStream())
                        {
                            image = System.Drawing.Image.FromStream(stream);
                        }
                    }
    
                    webRequest.ServicePoint.CloseConnectionGroup(webRequest.ConnectionGroupName);
                    webRequest = null; 
                }
