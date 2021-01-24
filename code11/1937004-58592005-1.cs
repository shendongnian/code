    [HttpPost]
    [ActionName("UploadImage")]
    [AllowAnonymous]
    [Route("[action]")]
    public async Task<string> UploadImage([FromForm] Model model) {
    
        _galleryService.InvokeAzureSettings(model.SchoolId, model.EnvironmentType);
        try {
            var res = await ((GalleryService)_galleryService).UploadImage(model.folder, model.file);
            return res;
        } catch (Exception ex) {
            return ex.ToString();
        }
    }
