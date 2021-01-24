    namespace xtra
    {
        class TestClass
        {
            public Dictionary<string, int> Dict { get; set; }
            public void Sing()
            {
                Dict = new Dictionary<string, int>()
                {
                    ["A"] = 1,
                    ["B"] = 2,
                    ["C"] = 3
                };
            }
        }
    }
    namespace ConsoleApp99
    {
        class Program
        {
            static void Main(string[] args)
            {
                xtra.TestClass Joe = new xtra.TestClass();
                Joe.Sing();
                foreach (string name in Joe.Dict.Keys)  //error!
                    sys.Console.WriteLine($"{name} {Joe.Dict[name]}"); //error!
            }
        }
    }
