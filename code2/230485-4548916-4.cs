     public class Persons
     {
       [JsonConverter(typeof(PairConverter))]
       public KeyValuePair<string, int> Age { get; set; }
     }
