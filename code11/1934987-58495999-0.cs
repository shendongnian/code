    public class Product
    {
    	public int Id { get; set; } = -1;
    	public List<ProductLink> Product_Links { get; set; } = new List<ProductLink>();
    	....
    	public int Visibility { get; set; } = 0;
    
    	public Product(IBaseProduct netforumProduct, MagentoClient client)
    	{
    	    var existingMagentoProduct = client.GetProductBySku(netforumProduct.Code);
    	    if (existingMagentoProduct != null)
    	    {
    			foreach (PropertyInfo property in typeof(Product).GetProperties().Where(p => p.CanWrite))
    			{
    			    property.SetValue(this, property.GetValue(existingMagentoProduct, null), null);
    			}
    	    }
    	}	
    }
