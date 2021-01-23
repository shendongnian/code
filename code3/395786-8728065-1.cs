    [HttpPost]
                public JsonResult Validate(string data)
                {
                    var response = HttpUtility.UrlDecode(data);
        
        
                    List<Investments> myDeserializedObjList = (List<Investments>)Newtonsoft.Json.JsonConvert.DeserializeObject(data, typeof(List<Investments>));
        
        
                    return Json(new
                    {
                        success = "This worked!"
                    },JsonRequestBehavior.AllowGet);
                }
