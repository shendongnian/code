`
        static void Main(string[] args)
        {
            var objectToSerialize = new Rootobject()
            {
                Drinks = new [] {"Coke", "Root Beer" },
                FoodType = new[] { "Pizza", "Pasta", "Bread" }
            };
            var serializedByTheLib = JsonConvert.SerializeObject(objectToSerialize);
            string jsonResult =
                "{ \"foodtype\": [\"Pizza\", \"Pasta\", \"Bread\"], \"drinks\": [\"Coke\", \"Root Beer\"] }";
            var deserializedObject = JsonConvert.DeserializeObject<Rootobject>(jsonResult);
        }
        public class Rootobject
        {
            [JsonProperty("foodType")]
            public string[] FoodType { get; set; }
            [JsonProperty("drinks")]
            public string[] Drinks { get; set; }
        }
    }
`
Take a look at [newtonsoft documentation][1] to get more info
  [1]: https://www.newtonsoft.com/json/help/html/Introduction.htm
