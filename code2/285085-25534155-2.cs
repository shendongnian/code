    public class MyClass
    {
        public bool MyProp
        {
            get;
            private set;
        }
        
        public int MyProp_AsInt
        {
            private get
            {
                return MyProp ? 1 : 0;
            }
            set
            {
                MyProp = (value > 0) ? true : false;
            }
        }
         
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyClass o = new MyClass();
            o.MyProp_AsInt = 1;
            System.Console.WriteLine("{0}", o.MyProp);
            o.MyProp_AsInt = 0;
            System.Console.WriteLine("{0}", o.MyProp);
            string line = System.Console.ReadLine();
        }
    }
