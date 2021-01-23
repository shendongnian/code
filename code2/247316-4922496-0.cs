    [TypeConverter(typeof(ExpandableObjectConverter))]
    class Foo2
    {
        private string name2;
        [CategoryAttribute("Category2")]
        public string Name2
        {
            get { return name2; }
            set { name2 = value; }
        }
    }
