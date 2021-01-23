    string csv = "Name,Surname,Telephone,Address";
    string[] split = csv.Split(',');
    
    DataGridViewTextBoxColumn subject = new DataGridViewTextBoxColumn();
    subject.HeaderText = "Subject Type";
    subject.Name = "Subject";
    
    dataGridView1.Columns.Add(subject);
    
    foreach (string item in split)
    {
        dataGridView1.Rows.Add(item);
    }
