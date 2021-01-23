private void saveButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isf.FileExists("myImage.jpg"))
                        isf.DeleteFile("myImage.jpg");
                    using (IsolatedStorageFileStream isfs = isf.CreateFile("myImage.jpg"))
                    {
                        var bmp = new WriteableBitmap(myImageElement, myImageElement.RenderTransform);
                        bmp.SaveJpeg(isfs, bmp.PixelWidth, bmp.PixelHeight, 0, 100);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
</pre>
