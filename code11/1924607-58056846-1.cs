    int numCols = dt.Columns.Count;
    foreach(String str in A){//loop all strings in arrays
     for(int i=0;i<numCols;i++){//loop all columnames in dataTable B
          string columnName =dt.Columns[i].Name.ToString();//get column Name
          //check if columnNames in B are equal to 
          if(!str.Equals(columnName){
            //remove column
             dt.Columns.RemoveAt(i);
          }else{
           //column name is equal to the string array
          }
       }
    }
