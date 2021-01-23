    public partial class MyEFModel
    {
        public IEnumerable<string> List
        {
            get
            {
                return SomeStringProperty.Split(',');
            }
            set
            {
                SomeStringProperty = string.Join(",", value.ToArray());
            }
        }
    }
