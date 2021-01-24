    foreach (string item in lbgenre2.Items)
    {
        //Here is your problem, you are creating a new Genere instead of using the already created
        var genre = new Genre();
        genre.Name = item;        
        genrelist.Add(genre);
    }
