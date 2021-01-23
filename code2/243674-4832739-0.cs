           var daysCount = DateTime.DaysInMonth(DateTime.Now.Year, 1);
            for (int i = 1; i <= daysCount; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewColumn() { HeaderText = i.ToString(), CellTemplate = new DataGridViewTextBoxCell() });
            }
