    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ass = Assembly.Load("ConsoleApplication1");
                var type = ass.GetType("ConsoleApplication1.Test");
                var obj = Activator.CreateInstance(type);
                Console.ReadLine();
    
                
            }
        }
    
        public class Test    {        }
    }
