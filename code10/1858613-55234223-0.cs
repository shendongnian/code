    public static void ProcessUserLikes(this SocialEntity socialProfile, AdlsClient adlsClient, string fileNameExtension = "")
            {
                using (MemoryStream memStreamLikes = new MemoryStream())
                {
                    using (TextWriter textWriter = new StreamWriter(memStreamLikes))
                    {
                        string header = FacebookHelper.GetHeader(delim, Entities.FBEnitities.Like);
                        string likes;
                        string fileName = adlsInputPath + fileNameExtension + "/likes.tsv";
                        adlsClient.DataLakeFileHandler(textWriter, header, fileName);
    
                        for (int i = 0; i < socialProfile.Likes.Count; i++)
                        {
                            for (int j = 0; j < socialProfile.Likes[i].Category_List.Count; j++)
                            {
                                likes = socialProfile.UserID
                                                + delim + socialProfile.FacebookID
                                                + delim + socialProfile.Likes[i].ID
                                                + delim + socialProfile.Likes[i].Name
                                                + delim + socialProfile.Likes[i].Category_List[j].ID
                                                + delim + socialProfile.Likes[i].Category_List[j].Name
                                                + delim + socialProfile.Likes[i].Created_time;
                                textWriter.WriteLine(likes);
                            }
                        }
                        textWriter.Flush();
                        memStreamLikes.Flush();
                        adlsClient.DataLakeUpdateHandler(fileName, memStreamLikes);
                    }
                }
            }
            private static void DataLakeFileHandler(this AdlsClient adlsClient, TextWriter textWriter, string header, string fileName = "")
            {
                if (!adlsClient.CheckExists(fileName))
                {
                    textWriter.WriteLine(header);
                }
            }
    
            public static void DataLakeUpdateHandler(this AdlsClient adlsClient, string fileName, MemoryStream memStream)
            {
                if (!adlsClient.CheckExists(fileName))
                {
                    using (var stream = adlsClient.CreateFile(fileName, IfExists.Overwrite))
                    {
                        byte[] textByteArray = memStream.ToArray();
                        stream.Write(textByteArray, 0, textByteArray.Length);
                    }
                }
                else
                {
                    memStream.Seek(0, SeekOrigin.Begin);
                    using (var stream = adlsClient.GetAppendStream(fileName))
                    {
                        byte[] textByteArray = memStream.ReadFully();
                        if (textByteArray.Length > 0)
                        {
                            stream.Write(textByteArray, 0, textByteArray.Length);
                        }
                    }
                }
            }
            public static byte[] ReadFully(this MemoryStream input)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    input.CopyTo(ms);
                    return ms.ToArray();
                }
            }
