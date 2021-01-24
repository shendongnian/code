    class Program
    {
        static int ADD(int a , int b){return a+b};
        static void Main(string[] args)
        {
            // error handling omitted!
            switch (args[0])
            {
            case "ADD":
                Consle.WriteLine("={0}", ADD(int.Parse(args[1]), int.Parse(args[2)));
                break;
            }
        }
    }
