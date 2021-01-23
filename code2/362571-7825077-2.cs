    [HttpPost]
    public ActionResult GetElements(string IDCampana)
    {
        Planilla query = db.Planillas.First();
        return Json(new PlanillaViewModel 
        { 
            Id = query.IDPlanilla, 
            Description = query.Description 
        });
    }
