    [WebMethod]
    public void bookRatedAdd(string title, int rating, string review, string ISBN, string userName)
    {
       using (OleDbConnection conn = new OleDbConnection(
             "Provider=Microsoft.Jet.OleDb.4.0;"+
             "Data Source="+Server.MapPath("App_Data\\BookRateInitial.mdb"));
       {
      
          conn.Open();
          // DbCommand also implements IDisposable
          using (OleDbCommand cmd = conn.CreateCommand())
          {
               // create command with placeholders
               cmd.CommandText = 
                  "INSERT INTO bookRated "+
                  "([title], [rating],  [review], [frnISBN], [frnUserName]) "+
                  "VALUES(@title, @rating, @review, @isbn, @username)";
                      
               // add named parameters
               cmd.Parameters.AddRange(new OleDbParameter[]
               {
                   new OleDbParameter("@title", title),
                   new OleDbParameter("@rating", rating),
                   ...
               });
               // execute
               cmd.ExecuteNonQuery();
          }
       }
    }
