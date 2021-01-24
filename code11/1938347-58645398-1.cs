     var client = new WebClient();     
     
     while (true)
            {
                try
                {
                    
                    using (var data = client.OpenRead("http://192.168.0.177/"))
                    {                
                        using (var reader = new StreamReader(data))
                        {
                            strResult = reader.ReadToEnd();
                            handleResult(strResult);
                            Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
