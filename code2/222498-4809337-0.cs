	interface IExtension { ... }
	class SomeExtension1 : IExtension { ... }
	class SomeExtension2 : IExtension { ... }
	class CommitCommand
	{
		public string Message;
		public bool AddRemove;
		public readonly IList<IExtension> Extensions = new List<IExtension>();
	}
