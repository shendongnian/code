    public ActionResult Action(RatingModel viewModel)
    {
        if (ModelState.IsValid) 
        {
            //Model is validated
        }
        else
        {
            return View(viewModel);
        }
    }
