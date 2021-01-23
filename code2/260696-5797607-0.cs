    using (FtpWebResponse response = (FtpWebResponse)ftpWebRequest.GetResponse())
            {
                try
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                           return reader.ReadToEnd();
                        }
                    }
                }
                finally
                {
                    response.Close();
                }
            }
