    public ActionResult Edit()
    {
       using(DataClasses1DataContext dc = new DataClasses1DataContext())
       {
         // here you can select some specific item from the ContentPageNavs list
         // Following query take first item from the list
         var model = dc.ContentPageNavs.FirstOrDefault();
         return View(model);
       }
    }
