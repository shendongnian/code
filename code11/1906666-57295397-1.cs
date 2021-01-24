     public class DocumentForCreationDto : IDto
        {
            //public string CreatedBy { get; set; }
            public string DocumentName { get; set; }
            public string MimeType { get; set; }
            public ICollection<DocumentTagInfoForCreationDto> Tags { get; set; }
        }
