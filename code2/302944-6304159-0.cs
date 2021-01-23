    public class AttachmentInfo : ViewModel
    {
        public string Path { get/set omitted }
    }
    public class EmailInfo : ViewModel
    {
        public ICollection<AttachmentInfo> Attachments { get omitted }
        public ICommand AddAttachmentCommand { get omitted }
    
        // logic for adding attachment simply adds another item to Attachments collection
    }
