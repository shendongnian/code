    public class item1
    {
        public string incomeAccount { get; set; }
        public string expenseAccount { get; set; }
        public string assetAccount { get; set; }
    }
    public static void ParseJson(string json)
    {
        var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        foreach (var keyvaluepair in keyValuePairs)
        {
            var obj = keyvaluepair.Value.ToString();
            decimal itemvalue;
            if (decimal.TryParse(obj, out itemvalue))
            {
                Console.WriteLine(itemvalue);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<item1>(obj);
                Console.WriteLine($"{ result.incomeAccount } - {result.expenseAccount} - {result.assetAccount}");
            }
        }            
    }
