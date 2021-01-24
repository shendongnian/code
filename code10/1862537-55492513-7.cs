    //Delete a file based on the ID that you get from your View
    [HttpPost]
    public JsonResult DeleteFile(string json)
    {
        var serializer = new JavaScriptSerializer();
        try
        {               
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
            string id = jsondata["id"];
            if(id != "")
            {             
                int getid = Convert.ToInt32(id);
                //Call your db or your logic to delete the file
                DatabaseAccess data = new DatabaseAccess();
                string result = data.DeleteFile(getid);
                if(result.Equals("Success"))
                {
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("fail", JsonRequestBehavior.AllowGet);
                }                     
            }
            else
            {
                return Json("notfound", JsonRequestBehavior.AllowGet);
            }
        }
        catch
        {
           return Json("dberror", JsonRequestBehavior.AllowGet);
        }
    }
