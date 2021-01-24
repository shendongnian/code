    public ActionResult Update(ProfileViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Not valid model");
        }
     //...
    }
