    public class Engineer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
    public class EngineerVM
    {
        public string Name { get; set; }
        public IFormFile File{ get; set; }
    }
