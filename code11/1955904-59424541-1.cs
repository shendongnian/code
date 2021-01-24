    public ActionResult Save(string json)
    { 
        IList<DemoViewModel> model = new
            JavaScriptSerializer().Deserialize<IList<DemoViewModel>>(json);
     
        //or
     
        List<DemoViewModel> model = new 
            JavaScriptSerializer().Deserialize<List<DemoViewModel>>(json);
    }
