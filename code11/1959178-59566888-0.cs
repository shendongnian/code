cs
public class MyController : ApiController {
  public IHttpActionResult Post(Class1 class1) {
    IHttpActionResult actionResult = ValidateSchema(class1);
    if(actionResult != null) {
      return actionResult;
    }
    //Do business stuff here
    return Ok();
  }
  private IHttpActionResult ValidateSchema(Class1 class1) {
    if(class1.ImportantInformation) {
      if(class1.A.X == null) {
        ModelState.AddModelError("A.X", "X is invalid");
      }
      if(class1.B.Y == null) {
        ModelState.AddModelError("B.Y", "Y is invalid");
      }
    }
    if(!ModelState.IsValid) {
      return BadRequest(ModelState);
    }
  }
}
