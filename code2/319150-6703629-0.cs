    public class MyViewModel
    {
        // This property represents the header value
        // you could use data annotations to localize it
        [Display(.. some localization here ..)]
        public string NameHeader { get; set; }
        // This property represents the data source that 
        // will be used to build the table
        public IEnumerable<User> Users { get; set; }
    }
