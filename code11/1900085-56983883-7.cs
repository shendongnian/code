    [HttpPost]
    public ActionResult Edit(int id, string name, string description){
        var item = db.Decisions.FirstOrDefault(a => a.Id == id);
        if (item != null)
        {
            // edit it
        }
        else 
        {
            // add it
        }
    }
