    [Authorize(Users="eestein,JasCav")
    public class MyController {
    }
    
    [Authorize(Roles="Administrator")]
    public class MyController {
    }
