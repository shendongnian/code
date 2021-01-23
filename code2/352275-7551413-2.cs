      public ActionResult YourAction(FormCollection oCollection)
      {
                    foreach (var key in oCollection.Keys)
                    {
                        //var value = oCollection[key.ToString()];
                    }
        
                    return View();               
      }
