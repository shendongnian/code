    public class BaseClass
        {
            int num;
            public BaseClass(int i)
            {
                num = i;
                Console.WriteLine("in BaseClass(int i)");
            }
        }
    public class DerivedClass : BaseClass
        {         
            // This constructor will call BaseClass.BaseClass(int i)
            public DerivedClass(int i) : base(i)
            {
            }
        }
