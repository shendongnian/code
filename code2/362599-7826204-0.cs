    // View code
    @using(Html.BeginForm(...)) {
        @Html.EditorForModel()
    }
    // Action code
    public ActionResult ShowForm(int userId)
    {
        var model = // get model from user ID;
        return View(model);
    }
    public ActionResult SaveForm(Model model)
    {
        if(ModelState.IsValid)
        {
            // Save model
        }
    }
