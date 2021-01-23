    class Program
    {
        public struct MyStructure
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public void Method(int Current, int Total)
            {
                if (Current < Total)
                {
                    System.Console.WriteLine(Current + ". " +  this.Name);
                    this.Method(Current + 1, Total);
                };
            }
        }
        static void Main(string[] args)
        {
            const int N = 100;
            MyStructure[] List = new MyStructure[N];
            List[0].Name = "Name";
            List[0].Method(0,N);
        }
    }
