    using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (Image pic = Image.FromStream(ms))
                {
                 pic.Save(DefaultImagePath+fileName.png, ImageFormat.Png);
                }
            }
