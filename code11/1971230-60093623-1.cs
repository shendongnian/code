    using System.Web.Script.Serialization;
    
    [HttpPost]
    public ActionResult PartialTabelaEcp(string json)
    {
    
      var serializer = new JavaScriptSerializer();
      dynamic jsondata = serializer.Deserialize(json, typeof(object));
    
      //Get your variables here from AJAX call
      var testFtT= jsondata["testFtT"];
      var test= jsondata["test"];
      var test2test= jsondata["test2test"];
      return PartialView("_TabelaEwidencja");
    }
