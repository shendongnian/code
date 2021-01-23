        [ExceptionHandler("DefaultError", typeof(DivideByZeroException))]
    public class HomeController : N2Controller
    {
       [ControllerAction, ExceptionHandler("Error")]
       public void Index()
       {
        
       }
    }
