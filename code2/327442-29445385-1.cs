    protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString()))
        {
            // Create a command object. 
            SqlCommand cmd = new SqlCommand();
            // Assign the connection to the command. 
            cmd.Connection = conn;
            // Set the command text 
            // SQL statement or the name of the stored procedure  
            cmd.CommandText = "DELETE FROM Products WHERE ProductID = @ProductID";
            // Set the command type 
            // CommandType.Text for ordinary SQL statements;  
            // CommandType.StoredProcedure for stored procedures. 
            cmd.CommandType = CommandType.Text;
            // Get the PersonID of the selected row. 
            string strProductID = gridview1.Rows[e.RowIndex].Cells[0].Text;
            // Append the parameter. 
            cmd.Parameters.Add("@ProductID", SqlDbType.BigInt).Value = strProductID;
            // Open the connection and execute the command. 
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        // Rebind the GridView control to show data after deleting. 
        BindGridView();
    }
