    DataGridViewProgressColumn column = new DataGridViewProgressColumn();
    
            kryptonDataGridView1.ColumnCount = 2;
            kryptonDataGridView1.Columns[0].Name = "TESTHeader1";
            kryptonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            kryptonDataGridView1.Columns[1].Name = "TESTHeader22";
            kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            kryptonDataGridView1.Columns.Add(column);
            kryptonDataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.HeaderText = "Progress";
            object[] row1 = new object[]  { "test1", "test2", 50 };
            object[] row2 = new object[] { "test1", "test2", 55 };
            object[] row3 = new object[] { "test1", "test2", 22 };
            object[] rows = new object[] { row1, row2, row3 };
            foreach (object[] row in rows)
            {
                kryptonDataGridView1.Rows.Add(row);
            }
