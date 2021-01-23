    public class RootElementClass
	{
		[XmlElement(ElementName = "Derived1", Type = typeof(Derived1BaseType))]
		[XmlElement(ElementName = "Derived2", Type = typeof(Derived2BaseType))]
		[XmlElement(ElementName = "Derived3", Type = typeof(Derived2BaseType))]
		public BaseType Declaration { get; set; }
	}
    public class BaseType { }
	public class Derived1BaseType : BaseType { }
	public class Derived2BaseType : BaseType { }
	public class Derived3BaseType : BaseType { }
