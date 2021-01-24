     StringBuilder strContent = new StringBuilder();
     foreach (DataGridViewColumn col in dgv.Columns)
     {
         if(col.Selected)
         {
            foreach (DataGridViewCell cell in col.Cells)
            { 
               strContent.Append(cell.Value.ToString());
               strContent.Append("\t");
            }
         }
      }
      Clipboard.SetText(strContent.ToString());
