	public class PriceWrap
    {
        public string Product { get; set; }
        public string Supplier { get; set; }
        // you can also add all price fields here, if you only want one level
        public Price Price { get; set; }
    }
	
	var bl = new BindingList<PriceWrap>();
	foreach (var quoteboard in quoteboards)
	{
		foreach (var kv in quoteboard.Prices)
		{
			var supplier = kv.Key;
			var price = kv.Value;
			bl.Add(new PriceWrap() {
				Product = quoteboard.Product,
				Supplier = supplier,
				Price = price
			});
		}
	}
    dataGridView1.DataSource = bl;
