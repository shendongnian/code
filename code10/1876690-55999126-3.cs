    private readonly ImageRewriteCollection rewriteCollection;
    public HomeController(ImageRewriteCollection rewriteCollection)
    {
        this.rewriteCollection = rewriteCollection;
    }
    [Route("images/{id}.jpg")]
    public IActionResult ResizeImage(int id, int width, int height)
    {
        rewriteCollection.TryAdd(id, width, height, "/resizedimagepath...");
        return File();
    }
