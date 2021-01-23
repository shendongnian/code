        [TypeConverter(typeof(MyCustomSelect))]
        public String Flavor
        {
            get { return _flavor; }
            set 
            {
                _flavor = value;
                OtherProperty = OtherCustomObject.Create(_flavor);
            }
        }
        private string _flavor;
        [Browsable(false)]
        public OtherCustomObject OtherProperty { get; set; }
