    public class Categories 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Categories() { }
        public Categories(string value, string text) 
        {
            this.Id = value;
            this.Title = text;
        }
    }
