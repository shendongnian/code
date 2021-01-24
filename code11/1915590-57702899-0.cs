    public JsonResult GetData()
        {
            JsonResult result = Json(new
            {
                rows = list.ToArray()
            }, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;
            return result;
        }
