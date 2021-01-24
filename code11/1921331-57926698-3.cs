    public class Item
	{	
		private List<Variant> _variants = new List<Variant>();
        public IEnumerable<Variant> Variants
        {
            get { return _variants.OrderByDescending(v => v.isOrdered); }            
        }
        public void AddVariant(Variant variant)
        {
            _variants.Add(variant);
        }
	}
