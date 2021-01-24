    private void DeleteSale_Click(object sender, EventArgs e)
    { 
          var RowId = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString(); 
        dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
        
        
        using(var connection = new SqlConnection("myConnectionString")
        {
             using(var command = new SqlCommand("myStoredProcedureName", connection))
             {
                  command.CommandType = CommandType.StoredProcedure;
                  command.Parameters.Add(new SqlParameter("Id", RowId));
                  command.Connection.Open();
                  command.ExecuteNonQuery();
                  command.Connection.Close();
              }
        }    
    }
