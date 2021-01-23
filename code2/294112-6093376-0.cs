    Dictionary<string, string> valueMap = new Dictionary<string, string>();
    valueMap.Add("Blue Cross Blue Shield", "BCBS");
    
    string Code = "";
    if(valueMap.ContainsKey(txtDesc.Text))
      Code = valueMap[txtDesc.Text];
    else
      // Handle
