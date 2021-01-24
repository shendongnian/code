    class Program
    {
        private static Func<Dictionary<string, object>, object> function1 = x =>
        {
            return ((int)x["x"] > (int)x["y"]) || (bool)x["z"];
        };
        private static Func<Dictionary<string, object>, object> function2 = x =>
        {
            if (((int)x["x"] > (int)x["y"]) || (bool)x["z"])
            {
                return 10;
            }
            else
            {
                return 20;
            }
        };
        static void Main(string[] args)
        {
            Dictionary<string, object> exampleVariables = new Dictionary<string, object>
            {
                {"x", 45},
                {"y", 0},
                {"z", true}
            };
            Console.WriteLine(Calculate(exampleVariables, function2));
        }
        public static object Calculate(Dictionary<string, object> variables, Func<Dictionary<string, object>, object> function)
        {
            return function(variables);
        }
    }
