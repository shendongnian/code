    using System;
    using System.Web.Script.Serialization;
    
    class Program
    {
    
        static void Main()
        {
            var json = 
    @"[
        [
            ""US\/Hawaii"", 
            ""GMT-10:00 - Hawaii""
        ], 
        [
            ""US\/Alaska"", 
            ""GMT-09:00 - Alaska""
        ]
    ]";
            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<string[][]>(json);
            foreach (var item in result)
            {
                foreach (var element in item)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
