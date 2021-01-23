     System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection("SomeConnectionString")
    
    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
    cmd.CommandText = "Insert Into tblExample (fldExample) Values (@fldExample)"; // Use a parameterized query to avoid SQL Injection
    cmd.Connection = cn;
    
    cmd.Parameters.AddWithValue("@fldExample", txtData.Text);  // Set the value of the parameter to the value of the textbox.
    
    try
    {
       cn.Open();
       cmd.ExecuteNonQuery();
       lblStatus.Text = "Item Inserted";
    }
    catch(Exception ex)
    {
       lblStatus.Text = ex.ToString();
    }
    finally
    {
       cn.Close();
    }
