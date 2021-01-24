request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
So the endresult would be:
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                        Console.WriteLine(html);
                    }
                }
            }
