    public bool TableContainsAnyRows()
    {
       // define a TOP 1 query - typically by the Primary Key of the table in question
       // using AdventureWorks sample database here
       string stmt = "SELECT TOP 1 [BusinessEntityID] FROM Person.Person ORDER BY [BusinessEntityID]";
       bool containsAnyRows = false;
       // open a connection and execute this query against the database 
       using(SqlConnection _con = new SqlConnection("server=.;database=AdventureWorks2008R2;integrated Security=SSPI;"))
       using(SqlCommand _cmd = new SqlCommand(stmt, _con))
       {
           _con.Open();
           // getting the result of the query
           // if the table contains *any* rows, the result will *NOT* be NULL
           object result = _cmd.ExecuteScalar();
           _con.Close();
           containsAnyRows = (result != null);
       }
 
       return containsAnyRows;
    }
