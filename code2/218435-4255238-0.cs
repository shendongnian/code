    void photoChooserTask_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            var contents = new byte[1024];
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var local = new IsolatedStorageFileStream("image.jpg", FileMode.Create, store))
                {
                    int bytes;
                    while ((bytes = e.ChosenPhoto.Read(contents, 0, contents.Length)) > 0)
                    {
                        local.Write(contents, 0, bytes);
                    }
                }
                // Read the saved image back out
                var fileStream = store.OpenFile("image.jpg", FileMode.Open, FileAccess.Read);
                var imageAsBitmap = PictureDecoder.DecodeJpeg(fileStream);
                // Display the read image in a control on the page called 'MyImage'
                MyImage.Source = imageAsBitmap;
            }
        }
    }
