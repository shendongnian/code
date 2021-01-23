    using System.Diagnostics;
        
    namespace DataBaseAccess
    {
        public static class Class1
        {
            private static string[] lines = System.IO.File.ReadAllLines("names.txt");
        
            public static void startgenerationofnames()
            {
                foreach (string value in lines)
                {
                    Debug.WriteLine(lines);
                    //call next class with the current value
                }
            }
        }
    }
