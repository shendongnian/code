    public class MyClass
    {
        private static Action NonStaticDelegate;
    
        public void NonStaticMethod()
        {
            Console.WriteLine("Non-Static!");
        }
    
        public static void CaptureDelegate()
        {
            MyClass temp = new MyClass();
            MyClass.NonStaticDelegate = new Action(temp.NonStaticMethod);
        }
    
        public static void RunNonStaticMethod()
        {
            if (MyClass.NonStaticDelegate != null)
            {
                // This will run the non-static method.
                //  Note that you still needed to create an instance beforehand
                MyClass.NonStaticDelegate();
            }
        }
    }
