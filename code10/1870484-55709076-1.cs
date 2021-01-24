    [HttpPost]
    public JsonResult GetChartData()
    {
        var timeStamp = Request["timeStamp"];
        var output = queryDatabase(timeStamp);
        var test = new JavaScriptSerializer().Serialize(output);
        return Json(output, JsonRequestBehavior.AllowGet);
    }
