    public BitmapImage ImageFromBytearray(byte[] imageData)
            {
    
                if (imageData == null)
                    return null;
                MemoryStream strm = new MemoryStream();
                strm.Write(imageData, 0, imageData.Length);
                strm.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
    
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                MemoryStream memoryStream = new MemoryStream();
                img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                memoryStream.Seek(0, SeekOrigin.Begin);
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
    
                return bitmapImage;
            }
