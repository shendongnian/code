    public class Foo
    {
        public MyClass BuildClass()
        {
            var dispObj = new DisposableObj();
            var retVal = new MyClass(dispObj);
            return retVal;
        }
    }
