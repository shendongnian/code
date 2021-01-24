    string[] item_list = new string[] { "XA=12345678;BK=AZ31", "XA=87654321" };  
    
    foreach(string item in item_list) {
      var namesAndValues = GetVariables(item);
      
      // If we have XA variable, assign its value to XA_EQ, otherwise assign ""
      string XA_EQ = namesAndValues.TryGetValue("XA", out string xa) ? xa : "";
      if (namesAndValues.TryGetValue("BK", out string BK_EQ)) {
        // If we have "BK" variable
        my_func(XA_EQ, BK_EQ);
      }
    }
