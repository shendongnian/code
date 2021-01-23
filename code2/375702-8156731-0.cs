    public void RentMovie( string titel , int movieID , string name , int customerID )
    {
      Customer  customer = FindCustomer( customerID , name ) ;
      MovieInfo movie    = FindMovie( movieID , titel ) ;
      
      if ( customer == null )
      {
        Console.WriteLine("No customer with that ID and name");
      }
      
      if ( movie == null )
      {
        Console.WriteLine("No movie with that titel and ID!") ;
      }
      
      if ( customer != null && movie != null )
      {
        string rentedMovie = string.Format( "{0}  ID: {1}" , movie.Titel , movie.MovieID );
        movie.rented = true;
        customer.customerRentedMovies.Add( rentedMovie );
      }
      
      return ;
    }
