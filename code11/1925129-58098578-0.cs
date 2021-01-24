    public class UserIdParams : CommonParams
     {
    [DataMember]
    public int UserId { get; set; }
    [DataMember]
    public List<int> ListUserId { get; set; }     
    }
