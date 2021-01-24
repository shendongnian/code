     [HttpPost]
     public JsonResult GetChartData([FromBody]string timeStamp)
     {
            string output = queryDatabase(timeStamp);
            string test = new JavaScriptSerializer().Serialize(output);
            return Json(output, JsonRequestBehavior.AllowGet);
     }
