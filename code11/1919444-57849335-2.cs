    public ActionResult ActionName()
    {
        planemosIdUi.Dto.Result model=new planemosIdUi.Dto.Result();// model object to partial view
        return PartialView("_CreateResult",model);
    }
