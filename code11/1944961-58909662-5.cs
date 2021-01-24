    using System.Web.Script.Serialization;
    public ActionResult ProcessMyData(string json)
    {
        try
        {
           var serializer = new JavaScriptSerializer();
           dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
            //Get your variables here from AJAX call
            int itemID= Convert.ToInt32(jsondata["itemID"]);
            double itemPrice=Convert.ToDouble(jsondata["itemPrice"])
    
            if(itemID > 0)
            {
                //Process your variables here
                bool result = DoSomethingWithMyData(itemID,itemPrice);
    
                //Handle result as required
                if(result==true)
                {
                    return Json(new{success = true}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new{success = false}, JsonRequestBehavior.AllowGet);
                }                  
            }
            else
            {
                return Json(new{success = false}, JsonRequestBehavior.AllowGet);
            }               
        }
        catch (Exception ex)
        {
            return Json(new{success = false}, JsonRequestBehavior.AllowGet);
        }
    }
