    public class MyViewModel
    {
        public string AnotherRegularProperty { get; set; }
    
        public IEnumerable<string> RawChildItems { get; set; }
    
        public string FormattedData
        {
            get
            {
                if (this.RawChildItems == null)
                    return string.Empty;
    
                string[] theItems = this.RawChildItems.ToArray();
    
                return theItems.Length > 0
                    ? string.Format("{0} ( {1} )", this.AnotherRegularProperty, String.Join(", ", theItems.Select(z => z.Substring(0, 1))))
                    : string.Empty;
            }
        }
    }
