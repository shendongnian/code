    public ActionResult controllername(FormCollection form)
    {
         foreach(string checkBoxName in dynamicCheckboxList)
         {
               var value = form[checkBoxName];
               //process value here
         }
    }
