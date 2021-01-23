    public class AdditionalAttachment: Attachment
    {
       public AdditionalAttachment(param1, param2) : base(param1, param2){}
       [DataMember]
       public string AttachmentURL
       {
           set;
           get;
       }
       [DataMember]
       public string DisplayName
       {
           set;
           get;
       }
    }
