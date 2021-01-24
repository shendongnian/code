    public class MyController : Controller, ILoggable {
        public MyController (IMyProvider<MyController> provider) {
            //...
        }
    } 
