    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;
    
    namespace Json
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(DeserializeNames());
                Console.ReadLine();
            }
    
            public static string DeserializeNames()
            {
                var jsonData = "{\"name\":[{\"last\":\"Smith\"},{\"last\":\"Doe\"}]}";
    
                JavaScriptSerializer ser = new JavaScriptSerializer();
    
                nameList myNames = ser.Deserialize<nameList>(jsonData);
    
                return ser.Serialize(myNames);
            }
    
            //Class descriptions
    
            public class name
            {
                public string last { get; set; }
            }
    
            public class nameList
            {
                public List<name> name { get; set; }
            }
        }
    }
