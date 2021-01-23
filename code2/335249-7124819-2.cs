        static Dictionary<string, Action<string>> Methods = new Dictionary<string, Action<string>>();
        public static void InitializeFunctions()
        {
            Methods.Add("ToLower", a => Console.WriteLine(a.ToLower()));
            Methods.Add("ToUpper", ToUpper);
        }
        static void ToUpper(string str)
        {
            Console.WriteLine(str.ToUpper());
        }
        public static void commandControl(string str, string param)
        {
            if(str.Length < 4)
                Console.WriteLine("Command must be more than 3 characters !...");
            if (Methods.ContainsKey(str))
                Methods[str].Invoke(param);
            else
                Console.WriteLine("Invalid Command");
        }
