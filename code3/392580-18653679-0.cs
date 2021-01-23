        public static void SaveToIsolatedStorage(FrameworkElement element, string file, bool scaled=true)
        {
            try
            {
                var bmp = new WriteableBitmap(element, null);
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                double width = Math.Round(element.ActualWidth * ((double)Application.Current.Host.Content.ScaleFactor / 100f), MidpointRounding.AwayFromZero);
                double height = Math.Round(element.ActualHeight * ((double)Application.Current.Host.Content.ScaleFactor / 100f), MidpointRounding.AwayFromZero);
                if (!scaled)
                {
                    width = element.ActualWidth;
                    height = element.ActualHeight;
                }
                using (var stream = iso.CreateFile(file))
                {
                    bmp.SaveJpeg(stream, (int)width, (int)height, 0, 100);
                    stream.Close();
                }
            }
            catch
            {
            } 
        }
