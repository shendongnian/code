    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Resources;
    
    namespace ConsoleApp1
    {
       public  class Student
        {
            
            public static void Main()
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
                {
                    resx.AddResource("Title", "Classic American Cars");
                    resx.AddResource("Name", "test1");
                    resx.AddResource("Age", "22");
                }
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                using (ResXResourceReader resxReader = new ResXResourceReader(@".\CarResources.resx"))
                {
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        pairs.Add(entry.Key.ToString(), entry.Value.ToString());
                        Console.WriteLine(entry.Value);
                    }
                }
                
                Console.WriteLine("success"); 
                 Console.ReadKey();
                
            }
        }
    }
