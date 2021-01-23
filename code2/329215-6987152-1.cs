    public class CustomerViewModel
    {
        public string Name { get; set; }
        private DateTime DateCreatedImpl { get; set; }
        public string DateCreated { get { return DateCreatedImpl.ToString(); }}
    }
