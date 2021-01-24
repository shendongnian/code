    public class File
    {
        public string Name { get; set; } // this is your file name property
        public string Description { get; set; } // this is your description property
        public string NameDescription => string.Format("{0} {1}", Name, Description); // the new property which contains name and description
    }
