c#
[HttpPost]
public JsonResult PostNewStamptime([FromBody] LoginModel model)
    {...}
 And LoginModel should contain key and login properties like Below
c#
public class LoginModel {
    public string Key {get;set;}
    public bool Login {get;set;}
}
Also, you can avoid using a model by altering endpoints statusVerb to Get and send the parameters in query strings. That's when you can reach them via [FromQuery]. **But this is semantically wrong.**
