    public class OwnerProductRegistration
    {
      public string CustomerFirstName { get; set; }
      public string CustomerPhoneMobile { get; set; }
      public List<AttachmentList> AttachmentLists { get; set; }
    }
    
    public class AttachmentList
    {
      public string FileName { get; set; }
      public string Description { get; set; }
    }
    
    OwnerProductRegistration model = new OwnerProductRegistration();
    AttachmentList attachmentList = new AttachmentList();
    
    model.CustomerFirstName = "Test";
    model.CustomerPhoneMobile = "1234567890";
    
    attachmentList.FileName = "FileNameTest";
    attachmentList.Description = "foo";
	
	model.AttachmentLists = new List<AttachmentList> { attachmentList };
