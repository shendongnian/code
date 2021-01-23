    public ActionResult YourAction(FormCollection oCollection)
    {
      var Item = new List<KeyValuePair<string, string>>();
      foreach (var key in oCollection.AllKeys)
       {
        Item.Add(new KeyValuePair<string, string>(key, oCollection[key]));
       }
    return View();                 
    }
