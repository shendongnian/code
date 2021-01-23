    using System;
    
    namespace DelegateTest
    {
        public delegate void SetValueDelegate(string value);
    
        public class Class1
        {
            public SetValueDelegate SetValueCallBack;
    
            public void Test()
            {
                if(SetValueCallBack != null)
                {
                    SetValueCallBack("Hello World!");
                }
            }
        }
    
        public class Class2
        {
            public void SetValueFunction(string value)
            {
                Console.WriteLine(value);
            }
        }
    
        public class Launcher
        {
            public static void Main(string[] args)
            {
                Class1 c1 = new Class1();
                Class2 c2 = new Class2();
                c1.SetValueCallBack += new SetValueDelegate(c2.SetValueFunction);
                c1.Test();
            }
        }
    }
