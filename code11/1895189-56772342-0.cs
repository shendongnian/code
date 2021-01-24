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
