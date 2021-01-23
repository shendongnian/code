    public ActionResult Index()
    {
        GalleryModel gm = new GalleryModel();
        var model = new ViewModel {
            UseJQuery = false,
            Title = "Image Gallery",
            Testy = gm.TestString            
        };
        return View(model);
    }
