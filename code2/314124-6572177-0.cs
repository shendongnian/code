    using (SqlConnection cnn = new SqlConnection("server=(local);database=pubs;Integrated Security=SSPI"))  {
     SqlDataAdapter da = new SqlDataAdapter("select name from authors", cnn); 
     DataSet ds = new DataSet(); 
     da.Fill(ds, "authors"); 
   
     List<string> authorNames = new List<string>();
     foreach(DataRow row in ds.Tables["authors"].Rows)
     {
	   authorNames.Add(row["name"].ToString());
     }
    }
