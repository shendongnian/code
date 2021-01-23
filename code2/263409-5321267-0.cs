    public class Person
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set
            {
                displayName = value;
                DisplayValue = value + " is a value";
            }
        }
        public string DisplayValue { get; set; }
        //... other properties
    }
