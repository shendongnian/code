       public void Save()
       {
          foreach (int row in dirtyRows)
          {
             this.UpdateRow(row, false);
          }
    
          dirtyRows.Clear();
       }
