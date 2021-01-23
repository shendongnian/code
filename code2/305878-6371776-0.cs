    DataTable dt = new DataTable();
    .....
    .....
    
        DataRowCollection drColl = dt.Rows;
                    for(int j=0; j<drColl.Count;j++) 
                    {
                        DataRow drRow = drColl[j];
                        object[] itemArr = null;
                        itemArr = drRow.ItemArray;
                        //loop through cells in that row       
                        for(int i=0; i<itemArr.Length; i++)
                        {         
                            //if the value is 0 change to null or blank 
                            if (itemArr[i].ToString() == "0")
                                drRow[i] = "";
                        } 
                    } 
