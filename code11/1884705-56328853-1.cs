	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class BindingAliasAttribute : Attribute
	{
		public string Alias { get; }
		public BindingAliasAttribute(string alias)
		{
			Alias = alias;
		}
	}
