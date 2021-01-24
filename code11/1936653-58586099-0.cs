    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2 cert = null;
                foreach (var certificate in store.Certificates)
                {
                    if (certificate.Subject.Contains("myhostname"))
                    {
                        cert = certificate;
                        break;
                    }
                }
                if (cert==null)
                {
                    return;
                }
                //output the public key
                string xmlKey = cert.PublicKey.Key.ToXmlString(false);
                //encoded
                string encodedkey = System.Net.WebUtility.HtmlEncode(xmlKey);
                Console.WriteLine($"Public key:\n{encodedkey}");
                store.Close();
                store.Dispose();
