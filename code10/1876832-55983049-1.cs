    public IActionResult OnGetDeleteImage(ImageType imageType)
    {
        return new ContentResult() {
           Content=GetPublicPathTo(DefaultImage(imageType)), //this should return something like "/img/the_image_to_display.png"
           ContentType="text/plain"
        }
    }
