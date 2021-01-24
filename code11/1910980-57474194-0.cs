    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main()
            {
                NamedList list = new NamedList();
                list.Key = "createdDate";
                list.Value.Add( "2019-07-20T05:53:28" );
                list.Value.Add( "2019-07-20T05:53:29" );
    
                string jsonString = JsonConvert.SerializeObject( list );
            }
        }
    
        public class NamedList
        {
            public string Key { get; set; }
            public List<string> Value { get; set; }= new List<string>();
        }
    }
