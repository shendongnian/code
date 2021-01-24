    public class ImageListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string ImageUrl { get; set; }
    
        public bool Checked { get; set; }
    
        public ImageListItem(string text, string value, string imageUrl)
        {
            Text = text;
            Value = value;
            ImageUrl = imageUrl;
            Checked = false;
        }
    }
