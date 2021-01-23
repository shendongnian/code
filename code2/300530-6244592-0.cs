    public class MyViewModel
    {
        public bool ShouldDisplayCommentsColumn 
        { 
            get 
            {
                return .... // Check the Items and decide whether you 
                            // should be showing the Comments column or not
            }
        }
        public IEnumerable<SomeOtherViewModel> Items { get; set; }
    }
