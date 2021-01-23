                    System.Drawing.Size size = LockAspectRatio(sFullFilePathAndName, Convert.ToInt32(rdPhoto.Width.Value) - 20, Convert.ToInt32(rdPhoto.Height.Value) - 80);
                    imgRep.Width = new Unit(size.Width);
                    imgRep.Height = new Unit(size.Height); 
    
    
    public System.Drawing.Size LockAspectRatio(string sFilePath, double maxWidth, double maxHeight)
        {
            int newWidth, newHeight;
            System.Drawing.Size size = new System.Drawing.Size();
            System.Drawing.Image image = System.Drawing.Image.FromFile(sFilePath);
    
            size.Width = image.Width;
            size.Height = image.Height;
    
            newWidth = image.Width;
            newHeight = image.Height;
    
            double imgRatio = (double)image.Width / (double)image.Height;
    
            //Step 1: If image is bigger than container, shrink it
            if (image.Width > maxWidth)
            {
                size.Height = (int)Math.Round(maxWidth * imgRatio, 0);
                size.Width = (int)maxWidth;
    
                newWidth = size.Width;
                newHeight = size.Height;
            }
    
            if (newHeight > maxHeight)
            {
                size.Height = (int)maxHeight;
                size.Width = (int)Math.Round(maxHeight * imgRatio, 0);  
            }
    
            //Step 2: If image is smaller than container, stretch it (optional)
            if ((image.Width < maxWidth) && (image.Height < maxHeight))
            {
                if (image.Width < maxWidth)
                {
                    size.Height = (int)Math.Round(maxWidth * imgRatio, 0);
                    size.Width = (int)maxWidth;
    
                    newWidth = size.Width;
                    newHeight = size.Height;
                }
    
                if (newHeight > maxHeight)
                {
                    size.Height = (int)maxHeight;
                    size.Width = (int)Math.Round(maxHeight * imgRatio, 0);
                }
            }
            return size;
        }
