    public class UserController : CustomBaseController
    {
        [HttpPost]
        public async Task<ActionResult> Login(LoginCredentialsModel model)
        {
            if(!ModelState.IsValid)
                return this.Fail(ModelState);
            // add your other custom logic here
            if(someLogic){
                return this.Success("your-message", additionalParams);
            } else {
                return this.Fail("custom-error-message", additionalParams);
            }
        }
    }
