    public static Size GetImageSize(string fileName)
            {
                #if __IOS__
                UIImage image = UIImage.FromFile(fileName);
                return new Size((double)image.Size.Width, (double)image.Size.Height);
                #endif
    
                return Size.Zero;
            }
