    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Databasename.accdb;Persist Security Info=false");
    
    int idLine;
    double grade;
    string comment;
    
    for (int i = 0; i < this.dataGridView4.Rows.Count-1; i++)
    {    
        idLine  = Convert.ToInt32(dataGridView4[0, i].Value);
        grade = Convert.ToDouble(dataGridView4[1, i].Value);
        comment = Convert.ToString(dataGridView4[2, i].Value);
    
        OleDbCommand cmd = new OleDbCommand("UPDATE archievemnet SET " + 
        " grade = " + grade +
        " comment = '" + comment + "' WHERE idLine = "+ idLine, conn);
        
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
