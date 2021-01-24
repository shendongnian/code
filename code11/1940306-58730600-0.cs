                    using (var responseWeb = await request.GetResponseAsync())
                    {
                        var response = (FtpWebResponse)responseWeb;
                        if (response.StatusDescription.Contains("150")) //150 Opening ASCII mode data connection for
                        {
                            using (var responseStream = response.GetResponseStream())
                            {
                                using (Stream fileStream = File.Create(destinationFile))
                                {
                                    responseStream.CopyTo(fileStream);
                                    returnvalue = true;
                                }
                            }
                        }
                    }
