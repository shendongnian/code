       public ActionResult AjaxProcessImage(string url)
       {
          try
          {
              ProcessImage(url);
          }
          catch(System.Exception ex)
          {
             return Json(
                   new
                   {
                      success = false,
                      msg = ex.Message
                   });
           }
          return Json(
                new
                {
                   success = true
                });
       }
