	public partial class ct_ServiceProductInfoWireless 
	{
		private WirelessItemBase[] itemsField;
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("NewWirelessLines", typeof(ct_WirelessLines))]
		[System.Xml.Serialization.XmlElementAttribute("WirelessLine", typeof(ct_ServiceProductInfoWirelessWirelessLine))]
		public WirelessItemBase[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
	}
	public abstract class WirelessItemBase
	{
	}
	public partial class ct_WirelessLines : WirelessItemBase
	{
	}
	public partial class ct_ServiceProductInfoWirelessWirelessLine : WirelessItemBase
	{
	}
