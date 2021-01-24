    public ActionResult ViewGrid(int dropdownId)
    {
        AModel model = new AModel
        {
            DropDownID = dropdownId
        };
        return PartialView("_theGridPartial", model);
    }
    
