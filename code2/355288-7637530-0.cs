            List<DataGridViewColumn> listOfColumns = new List<DataGridViewColumn>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                DataGridViewColumn col = dataGridView1.Columns[cell.ColumnIndex] as DataGridViewColumn;
                if (!listOfColumns.Contains(col))
                    listOfColumns.Add(col);
            }
            StringBuilder sb =new StringBuilder();
            foreach (DataGridViewColumn col in listOfColumns)
                sb.AppendLine(col.Name);
            MessageBox.Show("Column names of selected cells are:\n" + sb.ToString());
