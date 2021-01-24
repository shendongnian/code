    static void Convert()
    {
         string K = @"{ ""StringListNull"": null, ""StringListEmpty"": [], ""StringListPopulated"": [""one"", ""two""]}";
         var list= JsonConvert.DeserializeObject<ImportObject>(K);
        }
    
    public class ImportObject
    {
        public List<string> StringListNull { get; set; }
        public List<string> StringListEmpty { get; set; }
        public List<string> StringListPopulated { get; set; }
    }
