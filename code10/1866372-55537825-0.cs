    [HttpGet()]
    public IActionResult CreateTree()
    {
	    List<MyViewModel> viewModelList = MyViewModel.GetList();
	    return View("CreateTree", viewModelList);
    }
