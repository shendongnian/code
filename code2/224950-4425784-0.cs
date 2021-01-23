    public ActionResult controllername(FormCollection form)
    {
         foreach(string radioName in dynamicRadioList)
         {
               var value = form[radioName];
               //blah blah
         }
    }
