    private void ToCsV(DataGridView dGV, string filename)
        {
            string separator = ",";
            StringBuilder stOutput = new StringBuilder();
            // Export titles: 
            StringBuilder sHeaders = new StringBuilder();
            for (int j = 0; j < dGV.Columns.Count; j++)
            {
                sHeaders.Append(dGV.Columns[j].HeaderText);
                sHeaders.Append(separator);
            }
            stOutput.AppendLine(sHeaders.ToString());
            // Export data. 
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                StringBuilder stLine = new StringBuilder();
                for (int j = 0; j < dGV.ColumnCount; j++)
                {
                    stLine.Append(Convert.ToString(dGV[j, i].Value));
                    stLine.Append(separator);
                }
                stOutput.AppendLine(stLine.ToString());
            }
            File.WriteAllText(filename, stOutput.ToString());
        } 
