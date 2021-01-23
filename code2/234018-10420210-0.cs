    public void GetPhotoThumbnail(int realtyId, int width, int height)
    {
        // Loading photos’ info from database for specific Realty...
        var photos = DocumentSession.Query<File>().Where(f => f.RealtyId == realtyId);
    
        if (photos.Any())
        {
            var photo = photos.First();
    
            new WebImage(photo.Path)
                .Resize(width, height, false, true) // Resizing the image to 100x100 px on the fly...
                .Crop(1, 1) // Cropping it to remove 1px border at top and left sides (bug in WebImage)
                .Write();
        }
    
        // Loading a default photo for realties that don't have a Photo
            new WebImage(HostingEnvironment.MapPath(@"~/Content/images/no-photo100x100.png")).Write();
    }
