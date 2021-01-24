    public class Image
    {
        public int recipeId { get; set; }
        public string format { get; set; }
        public string description { get; set; }
        private byte[] _image { get; set; }
        public byte[] image { get { return _image; } set { 
            _image = value; 
            using(var ms = new MemoryStream(byteArrayIn)) ...
                imageFile = Image.FromStream(ms);...
        }
        public Image imageFile { get; set; }
    }
