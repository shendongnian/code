    [WebInvoke(UriTemplate = "Upload", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, Method = "POST")]
            public GenericObject SaveReceiptImage(System.IO.Stream imageStream)
            {
                                try
                {
                    byte[] buffer = new byte[16 * 1024];
    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read = 0;
                        while ((read = imageStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
    
                        ms.Position = 0;
    
                        if (ms.Length > 0)
                        {
                          //save your byte array to where you want
                        }
                        else
                        {
                          // woops, no image was passed in
                        }
                    }
                }
                catch (Exception ex)
                {
                    //bad error occured, log it
                }
    
                return whatever;
            }
