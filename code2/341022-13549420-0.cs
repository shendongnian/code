    protected override System.Net.WebRequest GetWebRequest(Uri uri)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
                if (PreAuthenticate)
                {
                    NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");
                    if (networkCredentials != null)
                    {
                        byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
                        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                    }
                    else
                    {
                        throw new ApplicationException("No network credentials");
                    }
                }
                request.KeepAlive = false;
                return request;
            }
