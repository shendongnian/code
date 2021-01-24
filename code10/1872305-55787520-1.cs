    public void PopulateList()
    {
    	var whatFile = "C:\\Users\\Daniel\\Desktop\\Couryah\\products_export.csv";
    	if ( ! System.IO.File.Exists( whatFile ))
    	{
    		MessageBox.Show("No such file: " + whatFile);
    		return;
    	}
    
    	foreach( var line in System.IO.File.ReadAllLines( whatFile ))
    	{ 
    		Product newProduct = new Product();
    		newProduct.setAll(line.Split(',')[1], line.Split(',')[3], Convert.ToDouble(line.Split(',')[19].Replace("$", "")), line.Split(',')[24]);
    		productList.Add(newProduct);
    	}
    }
