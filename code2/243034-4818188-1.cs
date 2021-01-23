    // The image will be read from isolated storage into the following byte array
            byte [] data;
 
            // Read the entire image in one go into a byte array
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Open the file - error handling omitted for brevity
                                     // Note: If the image does not exist in isolated storage the following exception will be generated:
                // System.IO.IsolatedStorage.IsolatedStorageException was unhandled
                // Message=Operation not permitted on IsolatedStorageFileStream
                using (IsolatedStorageFileStream isfs = isf.OpenFile("WP7Logo.png", FileMode.Open, FileAccess.Read))
                {
                    // Allocate an array large enough for the entire file
                    data = new byte[isfs.Length];
 
                    // Read the entire file and then close it
                    isfs.Read(data, 0, data.Length);
                    isfs.Close();
                }
            }
 
            // Create memory stream and bitmap
            MemoryStream ms = new MemoryStream(data);
            BitmapImage bi = new BitmapImage();
 
            // Set bitmap source to memory stream
            bi.SetSource(ms);
 
            // Create an image UI element – Note: this could be declared in the XAML instead
            Image image = new Image();
           
            // Set size of image to bitmap size for this demonstration
            image.Height = bi.PixelHeight;
            image.Width = bi.PixelWidth;
 
            // Assign the bitmap image to the image’s source
            image.Source = bi;
 
            // Add the image to the grid in order to display the bit map
            ContentPanel.Children.Add(image);
 
