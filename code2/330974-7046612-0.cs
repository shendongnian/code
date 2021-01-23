        [XmlElement("AttributesCustomList")]
        public list<string> _AttributesCustomList;
        [CategoryAttribute("Custom"), ReadOnly(false),
        Description("This property is customised to put new attributes")]
        //[RefreshProperties(RefreshProperties.All)]
        [RulesCriteria("Custom AttributesList")]
        public list<string> AttributesCustomList
        {
            get { return _AttributesCustomList; }
            set { _AttributesCustomList = value; }
        }
