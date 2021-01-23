    public bool WriteTransformedBitmapToFile<T>(BitmapSource bitmapSource, string fileName) where T : BitmapEncoder, new()
            {
                if (string.IsNullOrEmpty(fileName) || bitmapSource == null)
                    return false;
    
                //creating frame and putting it to Frames collection of selected encoder
                var frame = BitmapFrame.Create(bitmapSource);
                var encoder = new T();
                encoder.Frames.Add(frame);
                try
                {
                    using (var fs = new FileStream(fileName, FileMode.Create))
                    {
                        encoder.Save(fs);
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
    
            private BitmapImage GetBitmapImage<T>(BitmapSource bitmapSource) where T : BitmapEncoder, new()
            {
                var frame = BitmapFrame.Create(bitmapSource);
                var encoder = new T();
                encoder.Frames.Add(frame);
                var bitmapImage = new BitmapImage();
                bool isCreated;
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                    
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = ms;
                        bitmapImage.EndInit();
                        isCreated = true;
                    }
                }
                catch
                {
                    isCreated = false;
                }
                return isCreated ? bitmapImage : null;
            }
