    /// <summary>
    /// Runner should not contain dangerous methods! Access control and security aspects must be considered.
    /// </summary>
    public class Runner
    {
        /// <summary>Just to illustrate</summary>
        public int CallCount { get; set; }
        internal void MethodA(string a, string b, string c)
        {
            CallCount++;
            Console.WriteLine($"Hello the string World {a}, {b}, {c}!");
        }
        internal void MethodB(int d, int e)
        {
            CallCount++;
            Console.WriteLine($"Hello the int World, sum = {d + e}!");
        }
        internal void MethodC(string a, string b, string c, string d, string e)
        {
            CallCount++;
            Console.WriteLine($"Welcome to the world of the strings {a}, {b}, {c}, {d}, {e}!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Runner();
            ExecuteMethodWithSwitch(instance, "MethodA", "aaa", "bbb", "ccc");
            ExecuteMethod(instance, "MethodA", "aaa", "bbb", "ccc");
            ExecuteMethod(instance, "MethodB", 111, 222);
            ExecuteMethod(instance, "MethodC", "aaa", "bbb", "ccc", "monkey", "banana");
            //this is a testing-related statement
            System.Diagnostics.Debug.Assert(instance.CallCount == 4, "CallCount should be 4");
            Console.WriteLine($"Instance has been called {instance.CallCount} times...");
        }
        /// <summary>
        /// NOT RECOMMENDED WAY: Just use a switch statement and convert arguments like a noob.
        /// Only good thing about this is perhaps that is has more compile time checks.
        /// Incorrect arguments = exception.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        private static void ExecuteMethodWithSwitch(Runner runner, string methodName, params object[] args)
        {
            switch (methodName)
            {
                case nameof(runner.MethodA):
                    runner.MethodA(args[0]?.ToString(), args[1]?.ToString(), args[2]?.ToString());
                    break;
                case nameof(runner.MethodB):
                    var int1 = Convert.ToInt32(args[0]);
                    var int2 = Convert.ToInt32(args[1]);
                    runner.MethodB(int1, int2);
                    break;
                case nameof(runner.MethodC):
                    runner.MethodC(args[0]?.ToString(), args[1]?.ToString(), args[2]?.ToString(), args[3]?.ToString(), args[4]?.ToString());
                    break;
                default:
                    throw new ArgumentException($"Method with name {methodName} not known", nameof(methodName));
            }
        }
        /// <summary>
        /// RECOMMENDED WAY: Use reflection like a pro who actually likes C# and .NET.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        private static void ExecuteMethod(object o, string methodName, params object[] args)
        {
            //beautiful, no? Will continue to work even for newly added methods.
            var type = o.GetType();
            //NonPublic to get the 'internal' methods
            var methodInfo = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            methodInfo.Invoke(o, args);
        }
    }
