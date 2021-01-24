     StringBuilder strContent = new StringBuilder();
     foreach (DataGridViewColumn col in dgv.Columns)
     {
         if(col.Selected)
         {
             foreach (DataGridViewRow row in dgv.Rows)
             {
                strContent.Append(row.Cells[col.Index].Value.ToString());
                strContent.Append("\t");
            }
         }
      }
      Clipboard.SetText(strContent.ToString());
