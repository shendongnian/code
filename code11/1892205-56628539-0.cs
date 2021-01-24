    [ActionName("_CreateModal")]
    public ActionResult InsertNewRecord()
    {
        var model = new SampleModel(); // If Id is a GUID, then you could assign one here
        return PartialView("_CreateModal", model);
    }
