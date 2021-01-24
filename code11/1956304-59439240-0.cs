    public class ListItem
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public string DisplayValue 
        { 
            get
            {
                 return $"[{Value}] - {Description}";
            }
        }
    }
