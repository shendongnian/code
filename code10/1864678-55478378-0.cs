    public async void TakePhotoBasicAndSaveAndDisplayUWP()
    {
        var photoImplementation = new MediaCaptureImplementation();
        photoImplementation.TakePhotoTexture2DAsync();
        // Some code here...
    
        await photoImplementation.SavePhotoToPicturesLibraryAsync();
    }
    
