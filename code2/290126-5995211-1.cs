    public class DocumentStyle
    {
        public int DocumentId { get; set; }
        [ForeignKey("DocumentId")] // Should not be needed
        public Document Document { get; set; }
    }
