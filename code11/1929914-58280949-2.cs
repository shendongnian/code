	public class CartItem
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public override ToString()  // For displaying the Name in a listbox
		{
		    return Name;
		}
	}
