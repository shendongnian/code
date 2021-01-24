    // data from the query 
    // SELECT CODE, TOTALVALUE FROM vw_BuyersByCountryValue
	var sqldata = new [] 
	{ 
		new { Code = "AF", TotalValue = "$23,554,857.27" },  
		new { Code = "AS", TotalValue = "$38,379,964.65" },  
		new { Code = "SG", TotalValue = "$24,134,283.47" },  
	};
	
	var mappeddata = sqldata.Select( r => 
    {
	    var dict = new Dictionary<string,string>();
	    dict[r.Code] = r.TotalValue;
	    return dict;
    });
	var json = JsonConvert.SerializeObject(mappeddata,Formatting.Indented);
