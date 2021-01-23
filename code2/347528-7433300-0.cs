    public abstract class Document
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Document()
        {
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }
    }
    public class News : Document
    {
    }
    public class NotNews : Document
    {
    }
