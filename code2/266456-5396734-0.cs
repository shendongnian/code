        public interface ITest
        {
            int Test { get; }
        }
    
        public interface ITestExtended : ITest
        {
            new int Test { get; set; }
        }
    
        public class Monkey : ITestExtended
        {
            public int Test { get; set; }
    
            // Be carefull to explicitly implement the original interface
            int ITest.Test
            {
                get
                {
                    return 7;
                }
            }
        }
    
        public class MonkeySimple : ITest
        {
            public int Test
            {
                get { return 10; }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                ITestExtended monkey = new Monkey() { Test = 5 };
                ITest monkeySimple = monkey;
    
                Console.WriteLine(monkeySimple.Test);
                Console.WriteLine(monkey.Test);
    
                // Compiler error
                //monkeySimple.Test = 6;
    
                Console.ReadKey();
            }
        }
