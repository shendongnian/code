    string csv = "John,Doe,21";
    string[] split = csv.Split(',');
    
    DataGridViewTextBoxColumn firstName = new DataGridViewTextBoxColumn();
    DataGridViewTextBoxColumn lastName = new DataGridViewTextBoxColumn();
    DataGridViewTextBoxColumn age = new DataGridViewTextBoxColumn();
    
    dataGridView1.Columns.Add(firstName);
    dataGridView1.Columns.Add(lastName);
    dataGridView1.Columns.Add(age);
    
    dataGridView1.Rows.Add(split);
