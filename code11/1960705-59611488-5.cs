    using System.Web.Script.Serialization;
    
    [HttpPost]    
    public async Task<IActionResult> ExportToExcel(string json)
    {
        var serializer = new JavaScriptSerializer();
        dynamic jsondata = serializer.Deserialize(json, typeof(object));
        //Get your variables here from AJAX call
        var EmpName= jsondata["EmpName"];
        var EmpId=jsondata["EmpId"];
        var DeptId=jsondata["DeptId"];
        //Do something with your variables here    
        return Json("File exported successfully");
    }
