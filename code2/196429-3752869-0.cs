    public class MyClass
    {
        public delegate int MyFunctionDelegate(int some, string args);
        public MyFunctionDelegate MyFuncToCallFrmApp;
    
        public MyClass() : base() { }
        public SomeFunction()
        {
            if(MyFuncToCallFrmApp != null)
                MyFuncToCallFrmApp(_someOther, _argsLocal);
        }
    }
    
    public class Consumer
    {
        MyClass instance = new MyClass();
      
        public Consumer()
        {
            instance.MyFuncToCallFrmApp = new MyFunctionDelegate(MyFunc);
        }
    
        public void MyFunc(int some, string args)
        {
            // Do Something
        }
    }
