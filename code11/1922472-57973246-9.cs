    [HttpPost]
    public JsonResult ProcessJSON(string json)
    {
     // Your data variable is of type RootObject
     var data= JsonConvert.DeserializeObject<RootObject>(json);
    
     //Get your variables here as shown in first example. Something like:
     var unit=data.Units; //mm
     return Json(true);
    }
