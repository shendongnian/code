        static IEnumerable<Movie> NewPriceList()
        {
            var movieSequence = new[]
                                {
                                    new Movie("Harry potter", "Action/Thrill", 2011, 24.0),
                                    new Movie("Tooth fairy", "Family", 2010, 20.5),
                                    new Movie("How to train your dragon", "Family", 2010, 20.5)
                                };
            double priceMultiplier = 0.5;
            return movieSequence.Select(movie => movie.ChangePrice(priceMultiplier));
        }
