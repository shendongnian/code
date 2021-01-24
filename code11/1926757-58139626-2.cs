    string query = "select Height, Age from data where Id = @id";  // parameter @id in string 
    SqlCommand cmd1 = new SqlCommand(query, con3);              // create command with string
    
    var id = int.Parse(dataGridView1.SelectedCells[0].Value);   // parse id to int
    // create sql parameter and add to SqlCommand
    SqlParameter param1 = new SqlParameter("@id", id);
    cmd1.Parameters.Add(param1);
    // continue your code...
    SqlDataReader reader1 = cmd1.ExecuteReader();
    ....
