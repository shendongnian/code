    public class OtherInputModel
    {
        public string Text { get; set; }
        public string Body { get; set; }
        public FileHolder Holder { get; set; }
    }
    public class FileHolder
    {
        public IFormFile Image { get; set; }
    }
