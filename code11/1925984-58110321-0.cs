        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { 
            Name = "MaLopDangKy", 
            DataPropertyName = "MaLopDangKy", 
            HeaderText = "MaLopDangKy" });
        //Add rest of columns ...
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = list;
