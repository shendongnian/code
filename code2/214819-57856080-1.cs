    public ActionResult SaveData(string incoming, int documentId){
        // DeSerialize into your Model as your Model Array
        LineItem[] jsr = JsonConvert.DeserializeObject<LineItem[]>(Temp);
        foreach(LineItem item in jsr){
            // save some stuff
        }
        return Json(new { success = true, message = "Some message" });
    }
