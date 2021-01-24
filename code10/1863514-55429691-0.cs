    class Test : AbstractClassA
    {                 
        public Test()   
        {
            Invoke("SomeString", MethodDelegate);  // note, we passing only 1 string as parameter, so I changed MethodDelegate to accept only 1 string too
        }
        private void MethodDelegate(string a)
        { 
        }
    }
    
    public abstract class AbstractClassA {
        protected void Invoke(string a, Action<string> b)  // replaced second string with delegate
        {
            b(a);  // call passed action with passed parameter
        }
    }
