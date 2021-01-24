    dataGridView1.Columns.Add("col1", "Id");
    dataGridView1.Columns.Add("col2", "Name");
    dataGridView1.Columns.Add("col3", "Lname");
    List<string>[] list = new List<string>[3];
    list[0] = new List<string>() { "001", "002", "003"};
    list[1] = new List<string>() { "Tom", "Jerry", "Spike" };
    list[2] = new List<string>() { "T", "J", "S"};
    for(int i = 0;i< list[0].Count;i++)
    {
        dataGridView1.Rows.Add(list[0][i], list[1][i], list[2][i]);
    }
