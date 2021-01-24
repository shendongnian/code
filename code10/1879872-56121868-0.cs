    try
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        DataTable students = new DataTable();
        adapter.Fill(students);
        foreach(DataColumn col in students.Columns)
        {
            listBox1.Items.Add(col.ColumnName);
        }
    }
