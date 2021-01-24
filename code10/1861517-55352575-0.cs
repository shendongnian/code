    public ActionResult AddLostProperty(string models)
    {
        ...
        var data = JsonConvert.DeserializeObject<IEnumerable<LostPropertyViewModel>>(models);
        ...
    }
    
