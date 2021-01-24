	public class Item
	{	
		public List<Variant> Variants;
		public IOrderedEnumerable<Variant> OrderedVariants
		{
			get { return Variants.OrderByDescending(v => v.isOrdered); }
		}
		//OR
		public IOrderedEnumerable<Variant> GetOrderedVariants()
		{
			return Variants.OrderByDescending(v => v.isOrdered);
		}
	}
   
