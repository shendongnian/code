	public class RSLogix5000Content
	{
		[XmlAttribute] public List<AxisExceptionActionEnum>  CIPAxisExceptionAction { get; set; }
	}
	public enum AxisExceptionActionEnum
	{
		Default = 0,
		Value1 = (1<<0),
		Value2 = (1<<1)
	}
