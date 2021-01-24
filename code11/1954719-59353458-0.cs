    var names = new string[] { "User", "something" };
    
    foreach(var name in names)
    {
    
        var column = new DataGridViewTextBoxColumn
        {
            DataPropertyName = name,
            Name = name,
            HeaderText = name 
        };
        DataGridView1.Columns.Add(column);
    }
