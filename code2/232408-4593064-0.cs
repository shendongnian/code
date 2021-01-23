           // Get the object used to communicate with the server.
            var request = WebRequest.Create(url);
            request.Credentials = new NetworkCredential(username, password);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            try
            {
                using(var response = request.GetResponse())
                {
                    using(var stream = response.GetResponseStream())
                    {
                        using(var reader = new StreamReader(stream))
                        {
                            while(reader.Peek() >= 0)
                            {
				                 var line = reader.ReadLine();
				                 // check if this is a file or directory, filter list etc..
                            }
                        }
                    }
                }
            }
            catch
            {
            }
