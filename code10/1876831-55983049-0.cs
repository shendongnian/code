    public IActionResult OnGetDeleteImage(ImageType imageType)
    {
        return new ContentResult() {
           Content = "data:image/png;base64," + System.Convert.ToBase64String(System.IO.File.ReadAllBytes(DefaultImage(imageType))),
           ContentType = "text/plain"
        });
    }
