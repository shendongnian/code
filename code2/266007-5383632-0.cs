    public ActionResult GetMatchType(int id)
    {
        using (var db = new MatchGamingEntities())
        {
            var myMatchTypes = 
                from m in db.MatchTypes
                where m.GameId == id
                select new {
                    Text = m.MatchTypeName,
                    Value = m.MatchTypeId
                };
        }
        return Json(myMatchTypes, JsonRequestBehavior.AllowGet);
    }
