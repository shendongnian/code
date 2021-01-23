	public class order
	{
		private ItemType[] itemTypes;
		[XmlElement("ItemType")]
		public ItemType[] ItemTypes
		{
			get { return itemTypes; }
			set { itemTypes = value; }
		}
	}
	[XmlInclude(typeof(Thing))]
	[XmlInclude(typeof(Stuff))]
	public abstract class ItemType
	{
		private string type = "blah";
		[XmlAttribute("type")]
		public string Type
		{
			get { return type; }
			set { type = value; }
		}
	}
	public class Thing : ItemType
	{
		//...
	}
	public class Stuff : ItemType
	{
		//...
	}
