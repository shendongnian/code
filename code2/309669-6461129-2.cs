    class Program
    {
        static void Main()
        {
            var myRefType = new MyRefType();
            myRefType.MyInt = 0;
            var x = new whatever(myRefType);
            Console.WriteLine(x);
            myRefType.MyInt = 1;
            Console.WriteLine(x);
            Console.ReadKey();
        }
        class whatever
        {
            public whatever(MyRefType myRefType)
            {
                this.variable = () => myRefType.MyInt.ToString();
            }
            private Func<string> variable;
            public override string ToString()
            {
                return variable();
            }
        }
        class MyRefType
        {
            public int MyInt { get; set; }
        }
    }
