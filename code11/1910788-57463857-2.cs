		public class PriceInfo
		{
		   public string Name {get; set;}
		   public string RawPrice {get; set;}
		   public int Price => int.Parse(RawPrice.Trim('$'));
		}
