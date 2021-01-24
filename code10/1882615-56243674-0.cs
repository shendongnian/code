     using (var stream = new System.IO.FileStream(downloadPath + file.Id, System.IO.FileMode.Create))
                        {               
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            request.Download(stream);
                        }
