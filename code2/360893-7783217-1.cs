    // If column 3 is the checkbox column, we set its resize mode to none:
    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
    // Then we set the width:
    dataGridView1.Columns[3].Width = 25;
    // Finally we set the rest of the grid to fill or what ever resizing you need:
    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
