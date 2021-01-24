public class Data
    {
        public string name { get; set; }
        public string status { get; set; }
        public string classkey { get; set; }
    }
Back to wherever your JSON variable is, add `using Newtonsoft.Json;`, then use code like below:
List<Data> deserializedData = JsonConvert.DeserializeObject<List<Data>>(your variable name here);
This will get your data in a List of type Data. From there you can insert it into a SQLite database or do whatever, but you'll need to make your question more specific on what you mean by "tabular".
