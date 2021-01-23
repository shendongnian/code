      public ActionResult YourAction(FormCollection oCollection)
      {
                    foreach (KeyValuePair<int, String> item in oCollection)
                    {
                        //item.key
                        //item.value
                    }
        
                    return View();               
      }
