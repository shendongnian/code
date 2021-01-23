    public bool SaveUserQuery(string userName, Query query)
    {
       var db = new DataContext();
       if ( userName.ToLower() == "bob" ) 
       {
          List<Query> queries = new List<Query>();
          foreach ( var user in db.GetTable<Users>()) 
          {
             Query tempQuery = new Query(query.Name, query.FolderName, query.Layout,  query.Description, query.Query1, user.UserId);
             //and ofc create this constructor
             queries.Add(tempQuery);             
           }
           db.GetTable<Query>().InsertAllOnSubmit(queries);
           db.SubmitChanges();
           return true;
        }
    }
