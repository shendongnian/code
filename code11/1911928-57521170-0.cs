        int total = 0;
        for (int currentRow = 0; currentRow < dataGrid_Target.Rows.Count - 1; currentRow++)
        {
            bool IsRowDuplicate = false;
            DataGridViewRow rowToCompare = dataGrid_Target.Rows[currentRow];
            for (int otherRow = currentRow + 1; otherRow < dataGrid_Target.Rows.Count; otherRow++)
            {
                DataGridViewRow row = dataGrid_Target.Rows[otherRow];
                if (!row.IsNewRow)
                {
                    if (Convert.ToString(rowToCompare.Cells[0].Value).Equals(Convert.ToString(row.Cells[0].Value)))
                    {
                        IsRowDuplicate = true;
                        break;
                    }
                }
            }
            
            if(!IsRowDuplicate)
            {
               total++;
            }
        }
