    [HttpGet]
    [Route("PostAd")]
    public IActionResult PostAd() {
        var model = new PostAdViewModel();           
    
        model.Genres = getGenres();
        return View(model);
    }
    
    [HttpPost]
    [Route("PostAd")]
    public IActionResult PostAd(PostAdViewModel model) {
        if (ModelState.IsValid) {
            //...do something with model
            //and redirect if needed
        }
        //if we reach this far model is invalid
        //and needs to be repopulated
        model.Genres = getGenres();
        return View(model);
    }
