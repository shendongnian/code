     string result = "SELECT ACTIVE FROM [dbo].[test] WHERE ID=@ID";
     SqlCommand showresult = new SqlCommand(result, conn);
     // If ID is int type
     showresult.Parameters.Add("@ID",SqlDbType.Int).Value=ID.Txt; 
     // If ID is Varchar then 
     //showresult.Parameters.Add("@ID",SqlDbType.VarChar,10).Value=ID.Txt; 
    
      conn.Open();
      string actresult = (string)showresult.ExecuteScalar(); 
      conn.Close();
      if(!string.IsNullOrEmpty(actresult))
           ResultLabel.Text = actresult;
      else
           ResultLabel.Text="Not found";
