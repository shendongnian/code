	namespace yourApp.Infrastructure
	{
		[AttributeUsage(AttributeTargets.Property)]
		public class YourCustomAttribute : Attribute
		{
			private string attributeValue;
			
			public YourCustomAttribute(string value)
			{
				attributeValue = value;
			  
			}
			public string AttributeValue{ get => name; }
			
		}
	}
