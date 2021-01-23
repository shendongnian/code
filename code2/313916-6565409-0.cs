    int nID = int.Parse(Request.QueryString["nID"].ToString());
    niceMethod(nID);
    public string niceMethod(int nID) 
    { 
       using (var conn = new SqlConnection("Data Source=server;Initial Catalog=blah;Integrated Security=False;"))
       using (var cmd = conn.CreateCommand())
       {
            conn.Open();
            cmd.CommandText = @"SELECT bla, id, title FROM items WHERE main = @nID"; 
            cmd.Parameters.AddWithValue("@nID", nID);
            string tDate = cmd.ExecuteScalar().ToString();             
            return tDate;
       }
     }
     
