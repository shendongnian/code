    string jdata = File.ReadAllText(@"C:\Temp\json.txt");
    Response response = JsonConvert.DeserializeObject<Response>(jdata);
    response.Results.ForEach(x => x.ToList().ForEach(owner => dataTable.Rows.Add(owner.ToArray())));
            
    dataTable
        .Rows
        .Cast<DataRow>().ToList()
        .ForEach(x =>
        {
            dataTable.Columns.Cast<DataColumn>().ToList()
                .ForEach(y => Console.Write($"{x[y].ToString()}\t")); Console.WriteLine();
        });
And these are the classes i used. Class attributes should start with Capital letter and to conform to the standards, I used JsonProperty.
    public class Response
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<Result> Results { get; set; }
    }
    public class Result
    {
        public List<List<string>> ToList()
        {
            List<List<string>> response = new List<List<string>>();
            Owners.ForEach(x => response.Add(new List<string>() { MakeId, ModelId, x.Name, string.Join(",", x.Addresses.Select(address => address.City)) }));
            return response;
        }
        [JsonProperty("Make_ID")]
        public string MakeId { get; set; }
        [JsonProperty("Model_ID")]
        public string ModelId { get; set; }
        [JsonProperty("Make_Name")]
        public string MakeName { get; set; }
        [JsonProperty("Model_Name")]
        public string ModelName { get; set; }
        [JsonProperty("owners")]
        public List<Owner> Owners { get; set; }
    }
    public class Owner
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public List<Address> Addresses { get; set; }
    }
    public class Address
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("pincode")]
        public string PinCode { get; set; }
    }
**Output**
474     1861    Balaji  kcp
474     1861    Rajesh  chennai
475     1862    Vijay   madurai
475     1862    Andrej  Berlin
**Advantages**
1. Short and concise.. Based on classes you are defining so always will have the data in the correct place.
2. You dont need the Paths any more... works without the XML.
3. Easy to update the data returned from the `Result.ToList()`
