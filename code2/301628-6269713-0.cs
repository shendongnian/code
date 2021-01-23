    [Table(Name="Users")]
    class User
    {
       [Column]
       public Guid UserId;
    }  
    IEnumerable<User> questions;
    using (SqlConnection myConnection = new SqlConnection(myConnectionString))
    {
        var dc = new DataContext(myConnection);
       // Use ToArray to force all reads on the connection
        questions = 
            (from user in dc.GetTable<User>() 
            select new AllQuestionsPresented(user.UserId)).ToArray()
    }
    var threads = 
           from question in questions 
           select new DisplayAllQuestionsTable(question.SomeProperty);
