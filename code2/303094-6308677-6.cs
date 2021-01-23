    [DefaultProperty("Name")]
    public class CustomObject
    {
        [Description("Name of the thing")]
        public String Name { get; set; }
        [Description("Whether activated or not")]
        public bool Activated { get; set; }
        [Description("Rank of the thing")]
        public int Rank { get; set; }
        [Description("whether to persist the settings...")]
        public bool Ephemeral { get; set; }
        [Description("extra free-form attributes on this thing.")]
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
            "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
           typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(CsvConverter))]
        public List<String> ExtraStuff
        {
            get
            {
                if (_attributes == null)
                    _attributes = new List<String>();
                return _attributes;
            }
        }
        private List<String> _attributes;
    }
