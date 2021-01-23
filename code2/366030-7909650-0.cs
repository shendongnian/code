      private static IEnumerable<string> GetRowValues(this DataGridView dgv)
      {
         var list = new List<string>(dgv.Rows.Count);
         foreach (DataGridViewRow row in dgv.Rows)
         {
            var sb = new StringBuilder();
            foreach (DataGridViewCell cell in row.Cells)
            {
               sb.Append(cell.ToString());
            }
            list.Add(sb.ToString());
         }
         return list.AsReadOnly();
      }
