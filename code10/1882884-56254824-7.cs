    public ActionResult Caller(){
    var response = TempData["jsonData"];
    System.Reflection.PropertyInfo finalresult =response.GetType().GetProperty("result");
    string output = (string)(finalresult.GetValue(response, null));
    if (output == "success")
    ...
    }
