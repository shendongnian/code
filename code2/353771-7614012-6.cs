	[RequireAtLeastOne(GroupId = 0, ErrorMessage = "You must specify at least one owner phone number.", ErrorMessageKey = "OwnerPhone")]
	[RequireAtLeastOne(GroupId = 1, ErrorMessage = "You must specify at least one authorized producer phone number.", ErrorMessageKey = "AgentPhone")]
	public class User: IValidatableObject {
		#region Owner phone numbers
		// At least one is required
		[PropertyGroup(0)]
		public string OwnerBusinessPhone { get; set; }
		[PropertyGroup(0)]
		public string OwnerHomePhone { get; set; }
		[PropertyGroup(0)]
		public string OwnerMobilePhone { get; set; }
		#endregion
		#region Agent phone numbers
		// At least one is required
		[PropertyGroup(1)]
		public string AgentBusinessPhone { get; set; }
		[PropertyGroup(1)]
		public string AgentHomePhone { get; set; }
		[PropertyGroup(1)]
		public string AgentMobilePhone { get; set; }
		#endregion
	}
