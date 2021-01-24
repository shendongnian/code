    example : 
    decimal price = 0;
    var isValid = decimal.TryParse(
    	  PivotLine["Open"].TrimEnd(',').Trim() 				// the source string, remove last comma, and trim whitespace if any.
    	, System.Globalization.NumberStyles.AllowDecimalPoint 	// to get the decimal point
    	, new System.Globalization.CultureInfo("en-GB", true) 	// CultureInfo
    	, out price 											// The parsed value if parsible. 
    	);
    
    
    if(isValid) 
    {
    	// if the conversion is Success
    	txtPriceLastDay.Text = price.ToString(); // convert it to string again here. 
    }
    else	
    {
    	// IF conversion failed [Do Something]
    	txtPriceLastDay.Text = "0.00";
    }
