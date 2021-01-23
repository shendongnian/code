    Private string order = String.Empty;
    private void dgvDepartment_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    	if (order == "d")
    {
    		order = "a";				
    dataGridView1.DataSource = students.Select(s => new { ID = s.StudentId, RUDE = s.RUDE, Nombre = s.Name, Apellidos = s.LastNameFather + " " + s.LastNameMother, Nacido = s.DateOfBirth })   .OrderBy(s => s.Apellidos).ToList();
    	}
    	else
    	{
    		order = "d";
    		dataGridView1.DataSource = students.Select(s => new { ID = s.StudentId, RUDE = s.RUDE, Nombre = s.Name, Apellidos = s.LastNameFather + " " + s.LastNameMother, Nacido = s.DateOfBirth }.OrderByDescending(s => s.Apellidos)  .ToList()
    	}
    }
    
