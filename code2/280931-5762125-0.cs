    public class LegacyObject 
    {
        public Dictionary<string, string[]> MyLegacyProperty
        {
            get { return ConvertMyNewProperty(); }
            set { this.MyNewProperty = ConvertMyLegacyProperty(value); }
        }
        IEnumerable<KeyValuePair<string, string[]>> MyNewProperty { get; set; }
    }
