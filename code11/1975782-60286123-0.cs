    public ActionResult GetData()
    {
      using (Entity db = new Entity())
      {
         var htmltable = (from r in db.tableName WHERE r.idUser == "userX" &&
         r.columnY = 1
         select r).ToList();
         return Json(new { data = htmltable }, JsonRequestBehavior.AllowGet);
      }
    }
