         if (Request.QueryString["imageId"] != null)
                    {
                        int imgId= int.Parse(Request.QueryString["imageId"]);
    
    byte[] photoBytes= //get photo bytes from the DB here...
        
        
                        if (photoBytes != null)
                        {
                            if (photoBytes.Length > 0)
                            {
                                byte[] bImage;
                                bImage = photoBytes;
    
    //write the bytes to the response.. the page that has referenced this page as the img src will sow the image  
                                Response.BinaryWrite(bImage);
                                    
                            }
                        }
                    }
