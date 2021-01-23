    public ActionResult GetMatchType(int id)
    {
        using (var db = new MatchGamingEntities())
        {
            return Json(
                from m in db.MatchTypes
                where m.GameId == id
                select new {
                    Text = m.MatchTypeName,
                    Value = m.MatchTypeId
                },
                JsonRequestBehavior.AllowGet
            );
        }
    }
