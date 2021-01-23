    public class Document
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public DocumentStyle DocumentStyle { get; set; }
    }
