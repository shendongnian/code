        [ExceptionHandler("DefaultError", typeof(DivideByZeroException))]   <- Will not be used
    public class HomeController : N2Controller
    {
       [ControllerAction, ExceptionHandler("Error")]  <- Will be used
       public void Index()
       {
        
       }
    }
