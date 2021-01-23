    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            using (TextWriter fileTW = new StreamWriter("test.txt"))
            {
                fileTW.NewLine = "\n";            
                fileTW.WriteLine("Hello");
            }
        }
    }
