    public ActionResult Index()
    {
      ImageViewModel imageViewModel = new ImageViewModel();
      imageViewModel.Images = _imageRepository.GetImages();
    
      return View ("Index", imageViewModel);    
    
    }
