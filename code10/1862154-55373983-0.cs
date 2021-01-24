    SqlCommand q = new SqlCommand("DELETE FROM tabStoreExec  WHERE idSE =" + 
    txtIDL.Text.ToString(), sqliteCon);
    //string q = "DELETE FROM tabStoreExec  WHERE idSE =" + txtIDL.Text.ToString();
    q.ExecuteNonQuery();
     OR
        con.Open();
     using (SqlCommand q= new SqlCommand("DELETE FROM tabStoreExec  WHERE idSE =" + 
    txtIDL.Text.ToString(), sqliteCon))
     {
      q.ExecuteNonQuery();
     }
     con.Close();
    
