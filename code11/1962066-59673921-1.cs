    namespace Organisation.Models.User
    {
        public class PersonNoteAttachment
        {
            public string Alias { get; set; }
            public string FileName { get; set; }
            public string MimeType { get; set; }
        }
        public class PersonNote
        {
            public int Id { get; set; }
            public int PersonId { get; set; }
            public string Note { get; set; }
            public int AuthorId { get; set; }
            public List<PersonNoteAttachment> Attachments { get; set; }
            public string AuthorName { get; set; }
            public string CreatedBy { get; set; }
            public DateTime Created { get; set; }
        }
    }
