      [HttpPost]
      public ActionResult CategoryChanged(int value, int id)
      {
         try
         {
            //Save the change to the database
            SaveChangedCategoryValueToDatabase(id,value);
            //Create your View Model
            MyProductsViewModel vm = new MyProductsViewModel();
            
            return Json(new { success = true, newcontent =
               MyViewHelper.RenderPartialToString(this.ControllerContext, 
               "~/Views/Products/Products.ascx", 
               new ViewDataDictionary(vm), new TempDataDictionary()) });
         }
         catch(SystemException ex)
         {
             return Json(new { success = false, msg = ex.Message });
         }
            
      }
