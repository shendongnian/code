    var customer = customers.FirstOrDefault(c => c.Name == customerName && 
                                                 c.CustomerId == customerId);
    if (customer == null)
    {
        Console.WriteLine("No customer with that ID and name");
        return;
    }
    var movie = movies.FirstOrDefault(m => m.Name == movieName && 
                                      m.MovieId == movieId);
    if (movie == null)
    {
        Console.WriteLine("No movie with that ID and name");
        return;
    }
    movie.rented = true;
    string rentedMovie = string.Format("{0}  ID: {1}", movie.Titel, movie.MovieID);
    customer.customerRentedMovies.Add(rentedMovie);
