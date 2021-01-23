	[AttributeUsage(AttributeTargets.Field)]
	public class SampleAttribute : Attribute
	{
		public string MandatoryProperty { get; private set; }
		public string OptionalProperty { get; private set; }
		// we use an overload here instead of optional parameters because 
		// C# does not currently support optional constructor parameters in attributes
		public SampleAttribute(string mandatoryProperty)
			: this(mandatoryProperty, null)
		{
		}
		public SampleAttribute(string mandatoryProperty, string optionalProperty)
		{
			MandatoryProperty = mandatoryProperty;
			OptionalProperty = optionalProperty;
		}
	}
