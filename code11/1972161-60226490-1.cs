    using System.Web.Script.Serialization;
    [HttpPost]
    public JsonResult GetLargeImage(string json)
    {
        var serializer = new JavaScriptSerializer();
        dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
        //Get your variables here from AJAX call
        var i= jsondata["imageID"];
        var objectType= jsondata["imageType"];
        var imageResult = LoadSP_ImageLarge("sp_ImageLarge", i, objectType);
        List<ImageLarge> list_ImageLarge = new List<ImageLarge>();
        foreach (var row in imageResult)
        {
            list_ImageLarge.Add(new ImageLarge
            {
                Image_Data_string = (row.Image_Data != null) ? string.Format("data:" + row.Image_MimeType + ";base64,{0}", Convert.ToBase64String(row.Image_Data)) : null
            });
        }
        string imageString = list_ImageLarge.FirstOrDefault().Image_Data_string;
    
        return Json(imageString, JsonRequestBehavior.AllowGet);
    }
