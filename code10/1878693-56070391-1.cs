       var image = new CachedImage()
        {
            Source = ImageSource.FromStream(() => photo.GetStream())
        };
        image.Success += (sender, e) =>
        {
             var h = e.ImageInformation.OriginalHeight;
             var w = e.ImageInformation.OriginalWidth;
         };
