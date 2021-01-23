    private MovieInfo FindMovie( int movieID , string titel )
    {
      MovieInfo instance = null ;
      foreach( MovieInfo movie in movies )
      {
        if ( movie.MovieID == movieID && movie.Titel == titel )
        {
          instance = movie ;
          break ;
        }
      }
      return instance ;
    }
    
    private Customer FindCustomer( int customerID , string name )
    {
      Customer instance = null ;
      foreach( Customer customer in customers )
      {
        if ( customer.CustomerID == customerID && customer.Name == name )
        {
          instance = customer ;
          break ;
        }
      }
      return instance ;
    }
