 public class RootObject
        {
            [JsonProperty("dataset_data")]
            public Dataset dataset_data { get; set; }
        }
        public class Dataset
        {
            [JsonProperty("frequency")]
            public string frequency { get; set; }
            [JsonProperty("start_date")]
            public DateTime start_date { get; set; }
            [JsonProperty("end_date")]
            public DateTime end_date { get; set; }
            [JsonProperty("data")]
            public List<FseItem> data { get; set; }
        }
the problem is that my JSON Array doesn't have name for his elements. Looks like the only way to deserialize array to object is by using converter:
[JsonConverter(typeof(FseItemConverter))]
        public class FseItem
        {
            public DateTime Date { get; set; }
            public decimal? Open { get; set; }
            public decimal? High { get; set; }
            public decimal? Low { get; set; }
            public decimal? Close { get; set; }
            public decimal? Change { get; set; }
            public decimal? TradedVolume { get; set; }
            public decimal? TurnOver { get; set; }
            public decimal? LastPrice { get; set; }
            public decimal? TradedUnits { get; set; }
            public decimal? DailyTurnover { get; set; }
        }
 public class FseItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.Name.Equals("FseItem");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            return new FseReport.FseItem
            {
                Date = array[0].ToObject<DateTime>(),
                Open = array[1].ToObject<decimal?>(),
                High = array[2].ToObject<decimal?>(),
                Low = array[3].ToObject<decimal?>(),
                Close = array[4].ToObject<decimal?>(),
                Change = array[5].ToObject<decimal?>(),
                TradedVolume = array[6].ToObject<decimal?>(),
                TurnOver = array[7].ToObject<decimal?>(),
                LastPrice = array[8].ToObject<decimal?>(),
                TradedUnits = array[9].ToObject<decimal?>(),
                DailyTurnover = array[10].ToObject<decimal?>()
            };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var orderItem = value as FseReport.FseItem;
            JArray arra = new JArray();
            arra.Add(orderItem.Date);
            arra.Add(orderItem.Open);
            arra.Add(orderItem.High);
            arra.Add(orderItem.Low);
            arra.Add(orderItem.Close);
            arra.Add(orderItem.Change);
            arra.Add(orderItem.TradedVolume);
            arra.Add(orderItem.TurnOver);
            arra.Add(orderItem.LastPrice);
            arra.Add(orderItem.TradedUnits);
            arra.Add(orderItem.DailyTurnover);
            arra.WriteTo(writer);
        }
    }
And also, talking about big JSON data, it's much better to use ```Stream``` and ```JsonReader```, not ```string``` to read json data from URL:
HttpClient client = new HttpClient();
            using (Stream s = client.GetStreamAsync(url).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                var result = serializer.Deserialize<RootObject>(reader);
                return result.dataset_data.data;
            }
Hope this info will be helpfull for some one. Maybe there is some ways to improve this, but it works for me, so i'll post it here
