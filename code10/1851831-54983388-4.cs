     public class ValueObj
        {
            public string name { get; set; }
        }
        
        public class RootObject
        {
            public int id { get; set; }
            public string value { get; set; }
            public string another_value { get; set; }
            public ValueObj value_obj { get; set; }
            public List<int> value_list { get; set; }
        }
