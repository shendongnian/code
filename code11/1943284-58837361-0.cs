	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public class BranchCity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		private string DebuggerDisplay => $"Id: {id}, Name: {Name}";
	}
