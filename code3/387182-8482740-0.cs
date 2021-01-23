    [DataContract]
    public class User
    {
    	[DataMember(Name = "user_id")]
    	public int UserId { get; set; }
    
    	[DataMember(Name = "user_name")]
    	public string UserName { get; set; }
    }
