    dataGridView1.DataSource = students.Select(s => new { ID = s.StudentId, RUDE = s.RUDE, Nombre = s.Name, Apellidos = s.LastNameFather + " " + s.LastNameMother, Nacido = s.DateOfBirth })
                                       .OrderBy(s => s.Apellidos)
                                       .ToList();
    
        foreach(DataGridViewColumn column in dataGridView1.Columns)
        {
        
            dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
        }
