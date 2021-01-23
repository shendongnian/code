    public class TitleBodyModel
    {
        public string Title { get; set; }
    
        public string Body { get; set; }
    
        public TitleBodyModel() { Title = Body = ""; }
    
        public TitleBodyModel(string t, string b) { this.Title = t; this.Body = b; }
    }
