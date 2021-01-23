	public class ProductManufacturerInfo
	{
		public int IDX { get; set; }
		public bool Available { get; set; }
		public int C0ManufacturerIDX { get; set; }
		public virtual ManufacturerInfo C0Manufacturer { get; set; }
		public int C0ProductInfoIDX { get; set; }
		public virtual ProductInfo C0ProductInfo { get; set; }
	}
