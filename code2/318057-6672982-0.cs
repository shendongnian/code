    movies.Add(new Movie { 
       Title = "Pulp Fiction",
       Genres = { "Crime", "Thriller" } // calls Add on existing List
    });
    // or
    // assign a copy of genreList
    genreList.Clear();
    genrelist.Add("Adventure");
    genrelist.Add("Sci-Fi");
    movies.Add(new Movie { Title = "Back to the Future", Genres = genreList.ToList() });
