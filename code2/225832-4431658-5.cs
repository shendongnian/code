    using System;
    using System.Collections.Generic;
    
    public class DataObject
    {
        public string Category { get; set; }
        public int Id { get; set; }
    }
    
    class Test
    {
        
        static int count = 0;
        
        static DataObject ReadNextFile()
        {
            count++;
            return new DataObject
            {
                Category = count <= 5 ? "yes" : "no",
                Id = count
            };
        }
        
        static void Main()
        {
            List<DataObject> dataObjects = new List<DataObject>();
    
            DataObject nextObject;
            while((nextObject = ReadNextFile()).Category == "yes")
            {
                dataObjects.Add(nextObject);
            }
            
            foreach (DataObject x in dataObjects)
            {
                Console.WriteLine("{0}: {1}", x.Id, x.Category);
            }
        }
    }
