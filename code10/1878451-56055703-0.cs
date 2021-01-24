    public JsonResult GetCountryFlag(int supplierID)
        {
    
    bool flag = TODO // get flag from database based on supplierID
          
             return Json(flag, JsonRequestBehavior.AllowGet);            
        }
