    private async void SelectImageFromGallery(object sender, EventArgs e)
            {
                new ImageCropper
                {
                    CropShape = ImageCropper.CropShapeType.Rectangle,
                    Success = imageFile =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            
                            ...
    
                            Size s = GetImageSize(imageFile);
                            Console.WriteLine(s);
                        });
                    }
                }.Show(this);
    
            }
