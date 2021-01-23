    if (currentRow.Cells.Count > 0) 
    {      
       bool rowIsEmpty = true;    
       foreach(DataGridViewCell cell in currentRow.Cells)    
       {
          if(cell.Value != null) 
          { 
              rowIsEmpty = false;
              break;
          }    
       }
    
       if(rowIsEmpty)
       {
           MessageBox.Show("Select a non null row"); 
       }
       else
       {
           //DoStuff
       }
    }
