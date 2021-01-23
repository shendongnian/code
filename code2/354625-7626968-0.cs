          private void Pick_Click(object sender, RoutedEventArgs e)
          {
               var pc = new PhotoChooserTask();
               pc.Completed += pc_Completed;
               pc.Show();
          } 
            void pc_Completed(object sender, PhotoResult e)
            {
                var originalFilename = Path.GetFileName(e.OriginalFileName);
                SaveImage(e.ChosenPhoto, originalFilename, 0, 100);
            }
    
            public static void SaveImage(Stream imageStream, string fileName, int orientation, int quality)
            {
                using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorage.FileExists(fileName))
                        isolatedStorage.DeleteFile(fileName);
    
                    var fileStream = isolatedStorage.CreateFile(fileName);
                    var bitmap = new BitmapImage();
                    bitmap.SetSource(imageStream);
    
                    var wb = new WriteableBitmap(bitmap);
                    wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, orientation, quality);
                    fileStream.Close();
                }
            }
