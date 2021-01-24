    namespace MyApiNamesPace
    {
        public class MyController : ControllerBase
        {
            private readonly IMyClass _myClass;
            public MyClass(IMyClass myClass)
            {
                _myClass = myClass;
            }
            public IActionResult myAction()
            {
                _myClass.MyClassMethod();
            }
        }
    }
    
