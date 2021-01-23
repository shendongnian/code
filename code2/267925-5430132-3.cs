    public class MyProgram {
        public MyProgram()
        { 
            ILog logger = new Logger(); // instanciate it here instead.
            MyService myService = new MyService(logger);
            myService.DoSomething();
        } 
    }
