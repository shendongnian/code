    public class MyAnotherClass
    {
        private readonly MyClass _myClass;
    
        public MyAnotherClass(MyClass myClass)
        {
            _myClass = myClass;
        }
    
        public void CallingMethod(int c, int d)
        {          
            _myClass.Add( c, d);
        }
    }
