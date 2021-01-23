    public class Book
    {
      public string BookNum { get; set; }
      public string Title { get; set; }
      public string Author { get; set; }
    }
    [WebMethod(Description = "Gets the books matching part of a title.")]
    public List<Book> GetBooksByTitle(string strTitle) {
      OdbcConnection objConnection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Books"].ConnectionString);
      // Be careful.  You've got a SQL injection vulnerability here.
      OdbcCommand objCommand = new OdbcCommand("SELECT * FROM reading WHERE Title LIKE '%" + strTitle + "%' ORDER BY BookNum;", objConnection);
      DataTable dt = new DataTable();
      OdbcDataAdapter objDataAdapter = new OdbcDataAdapter(objCommand);
      objDataAdapter.Fill(dt);
      objConnection.Close();
      List<Book> result = new List<Book>();
      foreach (DataRow row in dt.Rows)
      {
        result.Add(new Book() {
          BookNum = row["BookNum"].ToString(),
          Title = row["Title"].ToString(),
          Author = row["Author"].ToString()
        });
      }
      return result;
    }
