    int numCols = B.Columns.Count;
    foreach(String str in A){//loop all strings in arrays
     for(int i=0;i<numCols;i++){//loop all columnames in dataTable B
          string columnName =B.Columns[i].ColumnName.ToString();//get column Name
          //check if columnNames in B are equal to 
          if(!str.Equals(columnName){
            MessageBox.Show("This names cannot be see in arrays");
          }else{
           //column name is equal to the string array
          }
       }
    }
