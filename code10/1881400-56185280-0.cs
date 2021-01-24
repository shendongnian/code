    class FunAllowedinput
    {
        public string FunctionName{get;set;}
    }
    public JsonResult FunAllowed(FunAllowedInput input)
    {            
        var records = db.Functions.Where(x => x.FunctionName == input.FunctionName).ToList();
        string result = "False";
        if (records.Count > 0)
            result = "True";
        return Json(records, JsonRequestBehavior.AllowGet);
    }
