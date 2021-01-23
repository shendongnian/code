    HttpWebRequest fileToDownload = (HttpWebRequest)HttpWebRequest.Create("YourURL");
                using (WebResponse fileDownloadResponse = fileToDownload.GetResponse())
                {
                    using (Stream fileStream = fileDownloadResponse.GetResponseStream())
                    {
                        using (StreamReader fileStreamReader = new StreamReader(fileStream))
                        {
                            char[] x = new char[Number];
                            fileStreamReader.Read(x, 0, Number);
                            string data = "";
                            foreach (char item in x)
                            {
                                data += item.ToString();
                            }
                        }
                    }
                }
