    try
    {
        using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Employee", cnn))
        {
            // Use DataAdapter to fill DataTable
            DataTable t = new DataTable();
            a.Fill(t);
    
            // Render data onto the screen
            dataGridView1.DataSource = t; //if you want.
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Problem!");
    }
