    public class Document
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
    Field<Document>(p => p.Text)
