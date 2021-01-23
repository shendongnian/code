    [DataContract]
    public class ChangePassword
    {
       [DataMember]
       public string OldPassword { get; set; }
       
       [DataMember]
       public string NewPassword { get; set; }
    }
