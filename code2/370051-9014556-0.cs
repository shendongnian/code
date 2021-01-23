	public partial class AgentAgency
	{
		public long OID { get; set; }
		public long? AgentOID { get; set; }
		public long? AgencyOID { get; set; }
		public string ReinsuranceYear { get; set; }
		public virtual Agency Agency { get; set; }
		public virtual Agent Agent { get; set; }
	}
    
	public class AgentAgencyMetadata
	{
		public Int64 OID { get; set; }
		[Required]
		public Int64 AgentOID { get; set; }
		[Required]
		public Int64 AgencyOID { get; set; }
	}
