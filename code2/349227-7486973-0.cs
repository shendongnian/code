        public class Outer
        {            
            [JsonProperty(PropertyName = "id")]
            public String Id { get; internal set; }
            [JsonProperty(PropertyName = "name")]
            public String Name { get; internal set; }
            [JsonProperty(PropertyName = "properties")]
            public Dictionary<String, String> Properties { get; internal set; }
            [JsonProperty(PropertyName = "inner_object")]
            public dynamic InnerObjectId { get; set; }
        }
        public void InnerObjectAsDynamic()
        {
            const string json = @"{""id"":""xyz"",""name"":""Some Object"",""properties"":{""prop_1"":""foo"",""prop_2"":""bar""},""inner_object"":{""id"":""abc$1"",""name"":""Inner Object Name""}}";
            var outer = JsonConvert.DeserializeObject<Outer>(json);
            var innerObjectJson = outer.InnerObjectId.ToString();
            Console.WriteLine(innerObjectJson);
            //{
            //  "id": "abc$1",
            //  "name": "Inner Object Name"
            //}
        }
