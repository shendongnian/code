    [HttpGet]
    [AllowAnonymous]
    public JsonResult RetreiveResume(int User)
    {
        var collection = new CND_PersonalData();
        using (var context = new DexusEntities())
        {
            collection = (from p in context.CND_PersonalData join
                              pd in context.CND_ProfessionalData on p.UserId equals pd.UserId join
                              ex in context.CND_ExperiencesData on p.UserId equals ex.UserId select p).ToList();
        }
        return Json(collection, JsonRequestBehavior.AllowGet);
    }
