    class Program
    {
            static void Main()
            {
                int i = 0;
            whatever x = new whatever(() => i.ToString());
            Console.WriteLine(x);
            i = 1;
            Console.WriteLine(x);
            Console.ReadKey();
        }
        class whatever
        {
            public whatever(Func<string> someFunc)
            {
                this.variable = someFunc;
            }
            private Func<string> variable;
            public string data;
            public override string ToString()
            {
                data = variable();
                return data;
            }
        }
     }
