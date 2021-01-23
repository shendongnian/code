       System.Text.StringBuilder queryaddress = new System.Text.StringBuilder();
    string sStreet = string.Empty;
    string sCity = string.Empty;
    string sState = string.Empty;
    string sPincode = string.Empty;
    string sProvider_no = string.Empty;
    queryaddress.Append("https://www.google.com/maps/dir/");
    
    if (!string.IsNullOrEmpty(txtprovider_no.Text)) {
    	sProvider_no = txtprovider_no.Text.Replace(" ", "+");
    	queryaddress.Append(sProvider_no + "," + "+");
    }
    if (!string.IsNullOrEmpty(txtState.Text)) {
    	sState = txtState.Text.Replace("  ", "+");
    	queryaddress.Append(sState + "," + "+");
    }
    if (!string.IsNullOrEmpty(txtCity.Text)) {
    	sCity = txtCity.Text.Replace("  ", "+");
    	queryaddress.Append(sCity + "," + "+");
    }
    if (!string.IsNullOrEmpty(txtPincode.Text)) {
    	sPincode = txtPincode.Text.Replace("  ", "+");
    	queryaddress.Append(sPincode);
    }
    
    queryaddress.Append("/");
    sStreet = string.Empty;
    sCity = string.Empty;
    sState = string.Empty;
    sPincode = string.Empty;
    if (!string.IsNullOrEmpty(txtlindmark.Text)) {
    	sStreet = txtlindmark.Text.Replace("  ", "+");
    	queryaddress.Append(sStreet + "," + "+");
    }
    if (!string.IsNullOrEmpty(txtclient_city.Text)) {
    	sCity = txtclient_city.Text.Replace("  ", "+");
    	queryaddress.Append(sCity + "," + "+");
    }
    if (!string.IsNullOrEmpty(ttxtclient_city.Text)) {
    	sPincode = ttxtclient_city.Text.Replace("  ", "+");
    	queryaddress.Append(sPincode);
    }
    if (!string.IsNullOrEmpty(txtclient_state.Text)) {
    	sState = txtclient_state.Text.Replace("  ", "+");
    	queryaddress.Append(sState + "," + "+");
    }
    
    
    WBR.Navigate(queryaddress.ToString());
