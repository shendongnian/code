json
[
    {
        "date": "20190405",
        "minute": "09:30",
        "label": "09:30 AM",
        "high": 196.47,
        "low": 196.14,
        "average": 196.271,
        "volume": 2360,
        "notional": 463200.325,
        "numberOfTrades": 26,
        "marketHigh": 196.48,
        "marketLow": 196.14,
        "marketAverage": 196.354,
        "marketVolume": 308339,
        "marketNotional": 60543617.1182,
        "marketNumberOfTrades": 712,
        "open": 196.47,
        "close": 196.21,
        "marketOpen": 196.45,
        "marketClose": 196.217,
        "changeOverTime": 0,
        "marketChangeOverTime": 0
    },
    {
        "date": "20190405",
        "minute": "09:31",
        "label": "09:31 AM",
        "high": 196.28,
        "low": 196.07,
        "average": 196.147,
        "volume": 2148,
        "notional": 421324.74,
        "numberOfTrades": 25,
        "marketHigh": 196.289,
        "marketLow": 195.93,
        "marketAverage": 196.113,
        "marketVolume": 210621,
        "marketNotional": 41305476.8289,
        "marketNumberOfTrades": 1018,
        "open": 196.1,
        "close": 196.26,
        "marketOpen": 196.22,
        "marketClose": 196.24,
        "changeOverTime": -0.0006317795293242263,
        "marketChangeOverTime": -0.0012273750471088639
    }
]
You could load the objects directly as a List, by using `List<DailyEquity>` as the Type for `JsonConvert.DeserializeObject<T>`
csharp
// Parsing directly to a List<>
List<DailyEquity> equities = JsonConvert.DeserializeObject<List<DailyEquity>>(/*put your parameters here*/);
I've setup some test cases for your scenario. The following gets me the Exception:
chsarp
    public void TestJsonDeserialize()
        {
            string jsonStr = /* your json string here */;
            var jsonObj = JsonConvert.DeserializeObject<DailyEquityRoot>(jsonStr);
        }
Changing the Deserialize type to a `List` of `DailyEquity` seems to do the job on my test case:
csharp
public void TestJsonDeserialize()
        {
            string jsonStr = /* your json goes here*/;
            
            var jsonObj = JsonConvert.DeserializeObject<List<DailyEquity>>(jsonStr);
            // Asserting the expected result we get from Deserializing
            Assert.NotEmpty(jsonObj);       // Asserts that the collection is not empty
            Assert.Equal(2, jsonObj.Count); // Asserts that the collection size is 2            
            var dailyEquityRecord = jsonObj.First();    // Let's take a look at the first object in the list
            Assert.NotNull(dailyEquityRecord);  // Asserting that the object has been loaded
            Assert.Equal("09:30 AM", dailyEquityRecord.label);  // Asserting that the label for the first record is as expected
        }
I used the following implementation of your json's class:
csharp
public class DailyEquity
        {
            public string date { get; set; }
            public string minute { get; set; }
            public string label { get; set; }
            public float high { get; set; }
            public float low { get; set; }
            public float average { get; set; }
            public int volume { get; set; }
            public float notional { get; set; }
            public int numberOfTrades { get; set; }
            public float marketHigh { get; set; }
            public float marketLow { get; set; }
            public float marketAverage { get; set; }
            public int marketVolume { get; set; }
            public float marketNotional { get; set; }
            public int marketNumberOfTrades { get; set; }
            public float open { get; set; }
            public float close { get; set; }
            public float marketOpen { get; set; }
            public float marketClose { get; set; }
            public float changeOverTime { get; set; }
            public float marketChangeOverTime { get; set; }
        }
