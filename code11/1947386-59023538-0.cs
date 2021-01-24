      string s = GetCellValue(row, col);
    
    
       string GetCellValue(int row, int col)
       {
    
       try
        {
          return (string)dataGridView1.Rows[row].Cells[col].Value);
        }
        catch
        {
            return null;
        }
       }
