       private async void ButtonClick(object sender, EventArgs eventArgs)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //"No Camera Available"
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(
            new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
            //Directory = "Sample",
            //Name = "Test.jpg"
        });
            if (file == null)
                return;
            var imgDate = GetImageStreamAsBytes(file.GetStream());
            // save it to folder
        }
 
