        public class DataTablesSearchModel
        {
            // properties are not capital due to json mapping
            [Newtonsoft.Json.JsonProperty(PropertyName = "draw")]
            public int Draw { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "start")]
            public int Start { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "length")]
            public int Length { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "columns")]
            public List<Column> Columns { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "search")]
            public Search Search { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "order")]
            public List<Order> Order { get; set; }
        }
    
        public class Column
        {
            [Newtonsoft.Json.JsonProperty(PropertyName = "data")]
            public string Data { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "searchable")]
            public bool Searchable { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "orderable")]
            public bool Orderable { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "search")]
            public Search Search { get; set; }
        }
    
        public class Search
        {
            [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
            public string Value { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "regex")]
            public string Regex { get; set; }
        }
    
        public class Order
        {
            [Newtonsoft.Json.JsonProperty(PropertyName = "column")]
            public int Column { get; set; }
    
            [Newtonsoft.Json.JsonProperty(PropertyName = "dir")]
            public string Dir { get; set; }
        }
