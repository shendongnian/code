    class Program
        {
            static void Main(string[] args)
            {
                bool allvalid = TestClasses().Any(t => !t.IsValid());
                Console.ReadLine();
            }
    
            public static IEnumerable<TestClass> TestClasses()
            {
                yield return new TestClass() { IsValid = () => { Console.Write(string.Format("TRUE{0}",Environment.NewLine)); return true; } };
                yield return new TestClass() { IsValid = () => { Console.Write(string.Format("FALSE{0}", Environment.NewLine)); return false; } };
                yield return new TestClass() { IsValid = () => { Console.Write(string.Format("TRUE{0}", Environment.NewLine)); return true; } };
                yield return new TestClass() { IsValid = () => { Console.Write(string.Format("TRUE{0}", Environment.NewLine)); return true; } };
            }
        }
    
        public class TestClass
        {
            public Func<bool> IsValid {get;set;}
        }
