    var lines = File.ReadAllLines("D:\\test.txt");
    var products = from line in lines
    			   select new 
    			   {
    			   		ProductManufacturer = line.Substring(0,12).Trim(),
    					ProductCode = line.Substring(12, 8).Trim(),
    					Description = line.Substring(20).Trim()
    			   };			   
    
    var xml = new XDocument(new XElement("xml", 
    	from p in products
    	select new XElement("Product",
    		new XElement("ProductManufacturer", p.ProductManufacturer),
    		new XElement("ProductCode", p.ProductCode),
    		new XElement("Description", p.Description))));
