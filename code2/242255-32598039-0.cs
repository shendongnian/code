       using (HttpWebResponse responseClaimLines = (HttpWebResponse)requestClaimLines.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(responseClaimLines.GetResponseStream()))
                        {
                            responseEnvelop = reader.ReadToEnd();
                        }
                    }
