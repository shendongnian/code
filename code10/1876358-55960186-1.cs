    public JsonResult Get()
    { 
        // Example  List
        var listMsg = reader.Cast<IDataRecord>().Select(x => new
        {
            textId = (int)x["textId"],
            textOwner = (string)x["textOwner"],
            textDateString =(x["textDate"].ToString())
         }).ToList();
    
         return Json(new { listMsg = listMsg }, JsonRequestBehavior.AllowGet);
     }
