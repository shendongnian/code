       public class Root
        {
            private string _CarriageReturns { get; set; }
            private string _Newlines { get; set; }
            private string _Spaces { get; set; }
            private string _Tabs { get; set; }
            [XmlElement(DataType = "normalizedString")]
            public string CarriageReturns
            {
                get { return _CarriageReturns; }
                set { _CarriageReturns = value.Trim(); }
            }
            [XmlElement(DataType = "normalizedString")]
            public string Newlines
            {
                get { return _Newlines; }
                set { _Newlines = value.Trim(); }
            }
            [XmlElement(DataType = "normalizedString")]
            public string Spaces
            {
                get { return _Spaces; }
                set { _Spaces = value.Trim(); }
            }
            [XmlElement(DataType = "normalizedString")]
            public string Tabs
            {
                get { return _Tabs ; }
                set { _Tabs = value.Trim(); }
            }
        }
