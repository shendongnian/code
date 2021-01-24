    class Program
    {
        static void Main(string[] args)
        {
            var rgs = new string[]
            {
                @"PathToYourDLL\My.dll",
                "/type:ClassNameToGen"
            };
    
            AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            {
                string error = e.Exception.ToString();
    
                var typeLoadException = e.Exception as ReflectionTypeLoadException;
    
                if (typeLoadException != null)
                {
                    foreach (var exception in typeLoadException.LoaderExceptions)
                    {
                        error += Environment.NewLine + Environment.NewLine + exception.ToString();
                    }
                }
    
                Console.WriteLine(error);
            };
    
            XsdTool.Xsd.Main(rgs);
    
            Console.ReadLine();
        }
    }
