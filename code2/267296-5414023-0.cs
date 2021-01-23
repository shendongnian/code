    public class MyClass
    {
        // This method is in the scope of MyClass
        public void MyMethod()
        {
            // This variable is in the scope of MyMethod.
            // It is only accessible from within this method because that is where
            // it is defined.
            string myString = "Hello Method.";
        }
        // This variable is in the scope of MyClass.
        // It is accessible within MyClass, including all methods that are also in scope
        // of MyClass
        public string myGlobalString = "Hello Global.";
    }
