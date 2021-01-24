        using System.Web.Script.Serialization;
        public ActionResult ProcessMyURLCount(string json)
        {
            try
            {
               var serializer = new JavaScriptSerializer();
               dynamic jsondata = serializer.Deserialize(json, typeof(object));
                //Get your variables here from AJAX call
                int getid= Convert.ToInt32(jsondata["idUrl"]);
                if(getid > 0)
                {
                    bool result = IncrementCountForURL(getid);
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
