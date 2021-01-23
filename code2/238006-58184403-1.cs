    public override DownloadItems GetItemStream(string itemID, object config = null, string downloadURL = null, string filePath = null, string)
        {
            DownloadItems downloadItems = new DownloadItems();
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    using (FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                    {
                        if (!string.IsNullOrEmpty(downloadURL))
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(downloadURL);
                            request.Method = WebRequestMethods.Http.Get;
                            request.PreAuthenticate = true;
                            request.UseDefaultCredentials = true;
                            const int BUFFER_SIZE = 16 * 1024;
                            {
                                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                                {
                                    using (var responseStream = response.GetResponseStream())
                                    {
                                        var buffer = new byte[BUFFER_SIZE];
                                        int bytesRead;
                                        do
                                        {
                                            bytesRead = responseStream.Read(buffer, 0, BUFFER_SIZE);
                                            fileStream.Write(buffer, 0, bytesRead);
                                        } while (bytesRead > 0);
                                    }
                                }
                                fileStream.Close();
                                downloadItems.IsSuccess = true;
                            }
                        }
                        else
                            downloadItems.IsSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                downloadItems.IsSuccess = false;
                downloadItems.Exception = ex;
            }
            return downloadItems;
        }
