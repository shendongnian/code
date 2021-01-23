     public class MyClass
    {
        public delegate object MyDelegate(object value);
        MyDelegate del1, del2, del3;
        public MyClass()
        {
            del1 = Method1;
            del2 = Method2;
            del3 = Method3;
            // remaining Ctr code here
        }
        public MyDelegate GetMethodByName(string methodName)
        {
            if (methodName.Equals("Method1"))
                return del1;
            if (methodName.Equals("Method2"))
                return del2;
            if (methodName.Equals("Method3"))
                return del3;
            return null;
        }
        public object Method1(object value)
        {
            // some code here
            return null;
        }
        public object Method2(object value)
        {
            // some code here
            return null;
        }
        public object Method3(object value)
        {
            // some code here
            return null;
        }
    }
