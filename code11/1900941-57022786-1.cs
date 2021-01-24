    namespace TestLibrary
    {
        public class ConsoleWriter
        {
            public void Write(string s)
            {
                Console.WriteLine(s);
                Console.WriteLine(System.Reflection.Assembly.GetCallingAssembly().GetName());
                Test();
            }
    
            private void Test()
            {
                Console.WriteLine("In test method");
                Console.WriteLine(System.Reflection.Assembly.GetCallingAssembly().GetName());
            }
        }
    }
