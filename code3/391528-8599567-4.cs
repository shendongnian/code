    public ActionResult Details(id)
    {
        var model  = new SomeModel();
        ViewData["IsFollowing"] = SomeRepository.IsFollowing(LoggedInUser.Id,id)
      
        return view();
    }
