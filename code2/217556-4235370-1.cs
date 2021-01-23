     var csvs = new List<string>();  
    csvs.Add( "Company Name 1,123 Main St."); 
     csvs.Add("Company Name 2,1 Elm St.,2 Elm St."); 
     
     var xml = 
     (from c in csvs 
     let split = c.Split(',')
     select  // split
     new XElement("ArrayOfBusiness", 
    	new XElement("Business", 
    		new XElement("Name", split[0] ), 
    		new XElement("AddressList", 
    		  new XElement("Address"
    		  	,
    			(from s in split.Where(x=>x != split[0])
    			select 
    			new XElement("AddressLine", s)) 
    		)
     )))); 
     
     xml.Dump();
 
 
