	public class Header
	{
		public int plVersion { get; set; }
		public int mID { get; set; }
		public int sID { get; set; }
	}
	public class AID
	{
		public object orID { get; set; }
	}
	public class Position
	{
		public double x { get; set; }
		public double y { get; set; }
	}
	public class MContainer
	{
		public AID aID { get; set; }
		public Position Position { get; set; }
	}
	public class RootObject
	{
		public int ID { get; set; }
		public Header header { get; set; }
		public MContainer mContainer { get; set; }
	}
