    var request = System.Net.WebRequest.Create(requestPath);
                request.Timeout = 12000;
                request.Method = "GET";
                request.Headers.Add("TRN-Api-Key", apiKey);
                request.ContentType = "application/json";
    
                try
                {
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                            jString = reader.ReadToEnd();
                        }
                    }
    
                }
                catch (System.Net.WebException e2)
                {
                    //MessageBox.Show(e2.Message);
                }
