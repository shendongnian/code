    namespace IO.Abstractions 
    {     
        public static class File
        {         
            public static Func<string, string, string> ExistsImpl =
                                                          System.IO.File.Exists;
            public static string Exists(string path)
            {             
                return ExistsImpl (path);
            }
        }
    } 
