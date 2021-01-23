    public class CustomDictionary
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public CustomDictionary(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    public class CustomDictionaryCollection : ObservableCollection<CustomDictionary>
    {
    }
    public class MyData
    {
        public CustomDictionaryCollection CustomPropertyTable { get; set; }
        public MyData()
        {
            this.CustomPropertyTable.Add(new CustomDictionary("myKey", "myValue"));
        }
    }
