    sqliteCon.Open();
    try
    {
        string sqlText = @"DELETE FROM tabStoreExec  WHERE idSE = @idse;
                           DELETE FROM tabList  WHERE idL = @idse;
                           DELETE FROM tabStoricoDetail  WHERE id = @idse;
       SqlCommand q = new SqlCommand(sqlText, sqliteCon);
       q.Parameters.Add("@idse", SqlDbType.Int).Value = Convert.ToInt32(txtIDL.Text);
       q.ExecuteNonQuery();
       // This is the point where you change the identity.
       // To minimize concurrency problems we execute a stored procedure instead 
       sqlText = "ResetIdentity";
       q.CommandText = sqlText;
       q.CommandType = CommandType.StoredProcedure;
       q.Parameters.Clear();
       q.ExecuteNonQuery();
       MessageBox.Show("Dato Cancellato Correttamente");
    }
    catch (SqlException ex)
    {
       MessageBox.Show(ex.Message);
    }
    sqliteCon.Close();
