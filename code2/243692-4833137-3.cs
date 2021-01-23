    int previousCustomerId = -1;
    
    List<string> deals = new List<string>();
    
    while(rs.ReadNext())
    {
       int customerId = rs["CustomerID"];
    
       if (customerId != previousCustomerId)
       {
           //Don't do this on the first go
           if (customerId != -1)
           {
              //Generate a filename
              string filename = GenerateFileName(customerId);  
    
              //There are better ways to write multiple values to a file,
              //  but this should give you an idea of where to start.
              File.AppendText(filename, "<customerData>");
          
              //Dump all of the DealXML values to the file
              foreach(string deal in deals)
                  File.AppendText(filename, deal);
    
              File.AppendText(filename, "</customerData>");
           }
    
           //Reinitialize the list
           deals = new List<string>();
    
           //Save the new customer id
           previousCustomerID = customerId;
    
       }
    
       deals.Add((string)rs["DealXML"]);
    }
