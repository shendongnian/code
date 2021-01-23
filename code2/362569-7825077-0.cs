    [HttpPost]
    public ActionResult GetElements(string IDCampana)
    {
        Planilla query = db.Planillas.First();
        return Json(new 
        { 
            Id = query.IDPlanilla, 
            Description = query.Description 
        });
    }
