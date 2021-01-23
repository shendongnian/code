    private MovieInfo FindMovie( int movieID , string titel )
    {
      return movies.Where( x => x.MovieID == movieID && x.Titel == titel ).SingleOrDefault() ;
    }
    
    private Customer FindCustomer( int customerID , string name )
    {
      return customers.Where( x => x.Name == name && x.CustomerID == customerID ).SingleOrDefault() ;
    }
