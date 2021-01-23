            for (int row = 0; row < 12; row++)
            {
                DataGridViewRow dr2 = new DataGridViewRow();
                DataGridViewCell[] cels = new DataGridViewCell[range.Columns.Count];
                for (int col = 0; col < range.Columns.Count; col++)
                {
                    cels[col].Value = (range.Cells[row, col] as Range).Value2.ToString();
                }
                dr2.Cells.AddRange(cels);
            }
