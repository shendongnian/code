         using (WebBrowser WebBrowser1 = new WebBrowser())
                {
                    String auth =
                        System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(_m3User + ":" + _m3Password));
                    string headers = "Authorization: Basic " + auth + "\r\n";
                    WebBrowser1.Navigate(h5URL, "_blank", null, headers);
                }
