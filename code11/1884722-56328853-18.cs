	using System;
	namespace MYDOMAIN.Client
	{
		[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
		public class BindingAliasAttribute : Attribute
		{
			public string Alias { get; }
			public BindingAliasAttribute(string alias)
			{
				Alias = alias;
			}
		}
	}
	
