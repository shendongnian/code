    public class MyClass
    { 
        private static void MyPrivateMethod()
        {
            // do stuff
        }
        public static void MyPublicMethod()
        {
            // do stuff
        }
    }
    public class SomeOtherClass
    {
        static void main(string[] args)
        {
             MyClass.MyPrivateMethod(); // invalid - this method is not visible
 
             MyClass.MyPublicMethod(); // valid - this method is public, thus visible
        }
    }
