    public ActionResult Details(id)
    {
        var model  = new SomeModel();
        model.IsFollowing = SomeRepository.IsFollowing(LoggedInUser.Id,id)
      
        return view(model);
    }
