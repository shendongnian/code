    var path = "";
    new ImageCropper
    {
        CropShape = ImageCropper.CropShapeType.Rectangle,
        Success = imageFile =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //profile_img.Source = ImageSource.FromStream(() => { return _mediaFile.GetStream(); });
                profile_img.Source = ImageSource.FromFile(imageFile);
                Debug.WriteLine("filepath2 " + path);
    
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                File.Copy(imageFile, Path.Combine(folderPath, "image.png"));
            });
        }
    }.Show(this);
