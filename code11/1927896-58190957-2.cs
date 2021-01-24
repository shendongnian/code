	public class BaseNode 
	{
	}
	public class B : BaseNode
	{
		[XmlElement("B", typeof(B))]
		[XmlElement("C", typeof(C))]
		[XmlElement("D", typeof(D))]
		public List<BaseNode> Nodes { get; } = new List<BaseNode>();
	}
	public class C : BaseNode
	{
		[XmlElement(ElementName="E")]
		public List<string> E { get; set; }
		[XmlElement(ElementName="F")]
		public List<bool> F { get; set; }
		[XmlElement(ElementName="G")]
		public G1 G { get; set; }
	}
	public class D : BaseNode
	{
		[XmlElement(ElementName="E")]
		public string E { get; set; }
		[XmlElement(ElementName="G")]
		public G2 G { get; set; }
	}
	public class G1
	{
		public string H { get; set; }
	}
	public class G2 
	{
		public string F { get; set; }
		public string E { get; set; }
	}
	[XmlRoot("A")]
	public class A
	{
		public B B { get; set; }
	}
