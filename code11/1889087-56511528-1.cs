    public class CustomBaseController : ControllerBase
    {
        public ActionResult Success(object value)
        {
            return new CustomActionResult(){ Data = value };
        }
        public ActionResult Success(string message, params object[] additionalParams)
        {
            if(additionalParams.Length > 0){
                return new CustomActionResult(){
                    Data = new { message, additionalParams }
                };
            }else{
                return new CustomActionResult() { Data = message };
            }
        }
        public ActionResult Fail(object value)
        {
            return new CustomActionResult(HttpStatusCode.BadRequest){ Data = value };
        }
        public ActionResult Fail(string message, params object[] additionalParams)
        {
            if(additionalParams.Length > 0){
                return new CustomActionResult(HttpStatusCode.BadRequest){
                    Data = new { ErrorMessage = message, additionalParams }
                };
            }else{
                return new CustomActionResult(HttpStatusCode.BadRequest){
                    Data = new { ErrorMessage = message }
                };
            } 
        }
    }
