    public class EmailModel {
        public EmailModel() {
            this.Attachments = new List<AttachmentModel>();
        }
    
        public string To { get; set; }
    
        public string Subject { get; set; }
    
        public string Body { get; set; }
    
        public List<AttachmentModel> Attachments { get; set; }
    
        public bool HasAttachments => this.Attachments != null && this.Attachments.Any(x => x.Content.Length > 0);
    }
    
    public class AttachmentModel {
        //...members
    }
