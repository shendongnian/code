    public async Task<IActionResult> SomeAction(....) {
        //...
        var bytes = await imagesService.GetArtistImageAsync(imageId);
        return File(bytes,  "image/jpeg");
    }
