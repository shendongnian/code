	public class Product
	{
		private float _price;
		public Product()
		{
			_price = 10.0F;
			Debug.WriteLine("Initializing price: {0}", _price);
		}
		public void ModifyPrice(float modifier)
		{
			_price = _price*modifier;
			Debug.WriteLine("New price: {0}", _price);
		}
	}
