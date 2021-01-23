    public static class Extender {
        public static string RowToString(this DataGridViewRow dgvr) {
            string output = "";
            DataGridView dgv = dgvr.DataGridView;
            foreach (DataGridViewCell cell in dgvr.Cells) {
                
                DataGridViewColumn col = cell.OwningColumn;
                output += col.HeaderText + ":" + cell.Value.ToString() + ((dgv.Columns.IndexOf(col) < dgv.Columns.Count - 1) ? ", " : "");
            }
            return output;
        }
    }
