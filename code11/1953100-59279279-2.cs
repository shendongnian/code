    public partial class ComplaintTicket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Attachment { get; set; }
        public Nullable<int> Ministry { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
