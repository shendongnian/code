    public abstract class MyBaseClass
    {
        public abstract void Initialize();
        public MyBaseClass()
        {
            // Code of the constructor of the base class
            // Calling the subclass 
            Initialize();
            // Finally call the special method
            MySpecialMethod();
        }
        private void MySpecialMethod()
        {
            // Some code here
        }
    }
    public class MySubclass : MyBaseClass
    {
        public override void Initialize()
        {
            // Some code here
        }
    }
