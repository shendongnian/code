        public class MyClass
        {
            private static int AddOne(int i)
            {
                return i += 1;
            }
            private int SubOne(int i)
            {
                return i -= 1;
            }
        }
    
        MyClass myClass = new MyClass();
        PrivateType privateTypeMyClass = new PrivateType(myClass.GetType());
        int res1 = (int)privateTypeMyClass .InvokeStatic("AddOne", 2);
        PrivateObject privateObjectMyClass = new PrivateObject(myClass);
        int res2 = (int)privateObjectMyClass.Invoke("AddOne", 2);
