        public class ItemInfo
        {
            [JsonProperty("cost")]
            public int Cost { get; set; }
            [JsonProperty("count")]
            public int Count { get; set; }
        }
        public class AllProdcuts
        {
            [JsonProperty("vk")]
            public ItemInfo VK { get; set; }
            [JsonProperty("ok")]
            public ItemInfo OK { get; set; }
            [JsonProperty("wa")]
            public ItemInfo WA { get; set; }
        }
        public class Stores
        {
            [JsonProperty("ID")]
            public string StoreID { get; set; }
            [JsonProperty("store")]
            public AllProdcuts Store { get; set; }
        }
and this is how you would call it 
    string jsonDoc = @"{
      ""0"": {
        ""vk"": {
            ""cost"": 19,
            ""count"": 1903
        },
        ""ok"": {
            ""cost"": 4,
            ""count"": 2863
        },
        ""wa"": {
            ""cost"": 4,
            ""count"": 2210
        }
      },
      ""1"": {
        ""vk"": {
            ""cost"": 9,
            ""count"": 3
        },
        ""ok"": {
            ""cost"": 4,
            ""count"": 63
        },
        ""wa"": {
            ""cost"": 40,
            ""count"": 210
        }
      }
    }";
    var obj = JObject.Parse(jsonDoc);
    List<Stores> allStores = new List<Stores>();
    foreach (var property in obj.Properties())
    {
        string storeNumber = property.Name;
        allStores.Add(new Stores() { StoreID = property.Name, Store = JsonConvert.DeserializeObject<AllProdcuts>(obj[property.Name].ToString()) });
    }
            
    // If you want to get list of <count, cost> for all stores
    List<ItemInfo> totalItemInAllStores = allStores.Select(x => x.Store.OK).ToList();
    int totalOKInAllStores = allStores.Sum(x => x.Store.OK.Count);
    int totalWAInAllStores = allStores.Sum(x => x.Store.WA.Count);
    int totalOkInXStore = allStores.FirstOrDefault(x => x.StoreID.Equals("0")).Store.OK.Count;
    string storeWithHighestCountOfOK = allStores.OrderBy(x => x.Store.OK.Count).Last().StoreID;
You can create separate methods for different sorting/queries you want to perform on each of the items for ease of getting the numbers you want.
