    if (!IsPostBack)
       SqlCommand cmd = new SqlCommand();
       cmd.Connection = new SqlConnection(Class1.CnnStr);
       SqlDataReader reader;
    
    
       cmd.CommandText = "select ChequeNo,ChequeDate from table where Number=@Number";
       cmd.Connection.Open();
       cmd.Parameters.AddWithValue("@Number", Number_lbl.Text);
       reader = cmd.ExecuteReader();
    
       if (reader.Read())
       {
    
           ChequeNo_txt.Text = reader["ChequeNo"].ToString();
           ChequeDate_txt.Text = reader["ChequeDate"].ToString();
           reader.Close();
       }
       cmd.Connection.Close();
    }
