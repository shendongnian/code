    // Classes to Deserialize data we need.
    public class MyObject
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Data
    {
        public int A { get; set; }
        public int B { get; set; }
    }
**Usage in Main**
    // Read in the JSON
    var myData = JsonConvert.DeserializeObject<dynamic>(jsonString)["myData"];
    
    // Convert To Dictionary
    Dictionary<string, dynamic> dataAsObjects = myData.ToObject<Dictionary<string, dynamic>>();
    string searchFor = "3";
    dataAsObjects.TryGetValue(searchFor, out dynamic obj);
    if (obj != null)
    {
        // Conversion to int and matching against searchFor is to ensure its a number.
        int.TryParse(searchFor, out int result);
        if (result == 0 && result.ToString().Equals(searchFor))
        {
            MyObject myObject = obj.ToObject<MyObject>();
            Console.WriteLine($"A:{myObject.Data.A} - B:{myObject.Data.B}");
        }
        else if (result == 8 && result.ToString().Equals(searchFor))
        {
            // I am not clear on whats your parameters class look like.
            MyParameters myParams = obj.ToObject<MyParameters>();
        }
    }
**Output**
A:1 - B:2
With this method you can either access the numbers or the parameters element. 
