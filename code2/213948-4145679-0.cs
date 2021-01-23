    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {        
        static void Main()
        {
            string originalFile = "Test.cs";
            string relative = @"..\Documents\Foo";
            
            string originalAbsoluteFile = Path.GetFullPath(originalFile);        
            string originalDirectory = Path.GetDirectoryName(originalAbsoluteFile);
            string combined = Path.Combine(originalDirectory, relative);
            string combinedAbsolute = Path.GetFullPath(combined);
            Console.WriteLine(combinedAbsolute);
        }
    }
