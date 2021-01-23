	[DataContract(Name = "session")]
	[DataContractJsonModelBinder]
	public class FacebookSession
	{
		[DataMember(Name = "access_token")]
		public string AccessToken { get; set; }
		[DataMember(Name = "expires")]
		public int? Expires { get; set; }
		[DataMember(Name = "secret")]
		public string Secret { get; set; }
		[DataMember(Name = "session_key")]
		public string Sessionkey { get; set; }
		[DataMember(Name = "sig")]
		public string Signature { get; set; }
		[DataMember(Name = "uid")]
		public string UserId { get; set; }
	}
