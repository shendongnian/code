    using(FileStream file = new FileStream("test.xml", FileMode.Create))
    {   
        var columnNames =
            dataGridView1.Columns
            .Cast<DataGridViewColumn>()
            .OrderBy(x => x.ColumnIndex)
            .Select(x => x.Name);
    
        foreach(string column in columnNames)
            file.WriteLine(column);
    }
