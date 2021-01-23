    if (bmp != null)
                {
    
                    // Crop the image.
                    picImage = (System.Drawing.Image)bmp.Clone(new Rectangle(10, 0, 492, 768), bmp.PixelFormat);
                    
    	**Bitmap img = new Bitmap(picImage);
    	picImage.Dispose();
    	picImage = null;**
    	  
    	  try
                    {
                        if (picImage != null)
                            **this.picLiveView.Image = img;**
                    }
                    catch (Exception ex)
                    {
                        Utility.HandleError(ex);
                    }
    
    
                }
