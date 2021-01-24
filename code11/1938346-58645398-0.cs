     var client = new WebClient();     
     while (true)
            {
                try
                {
                    
                    Stream data = client.OpenRead("http://192.168.0.177/");
                    StreamReader reader = new StreamReader(data);
                    strResult = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                    handleResult(strResult);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                }
            }
