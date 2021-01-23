    namespace XMLParse
    {
        class Class1
        {
    
            public static void Main()
            {
    
                string[] Files = Directory.GetFiles(@"C:\onlinesales");
                foreach (string filename in Files)
                {
    
                    //...YOUR CODE
                }
    
                //....ADD THIS LINE
                Array.ForEach(Directory.GetFiles(@"c:\onlinesales\", "*.xml"),
                  delegate(string path) { File.Delete(path); });
            }
        }
    }
