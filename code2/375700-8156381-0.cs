    public void RentMovie(string titel, int movieID, string name, int customerID) 
        {
            bool hasCustomer, hasMovie;
    
            hasCustomer = false;
            hasMovie = false;
    
            foreach (Customer customer in customers)  
            {
                if (name == customer.Name && customerID == customer.CustomerID)  
                {
                    hasCustomer = true;
                    foreach (MovieInfo movie in movies)
                    {
                        if (titel == movie.Titel && movieID == movie.MovieID)
                        {
                            hasMovie = true;
                            movie.rented = true;
                            string rentedMovie = string.Format("{0}  ID: {1}", movie.Titel, movie.MovieID);
                            customer.customerRentedMovies.Add(rentedMovie); 
    
                            break; 
                        }
    
                    }
                    if (hasMovie == false) {
                        Console.WriteLine("No movie with that titel and ID!");
                    }
                 break;      
                }
            }
    
            if (hasCustomer == false) {
                Console.WriteLine("No customer with that ID and name");
            }
        }
