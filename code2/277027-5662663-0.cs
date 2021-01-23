        ArrayList products = new ArrayList();
    
        ArrayList productDetail = new ArrayList();
    
        productDetail.Clear(); 
        
           foreach (DataRow myRow in myTable.Rows)
             {
                                  
              productDetail.Add( "CostPrice" + "," + myRow["CostPrice"].ToString());
    
              products.Insert(myTable.Rows.IndexOf(myRow),(object)productDetail);
             }
