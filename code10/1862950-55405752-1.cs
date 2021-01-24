    foreach (string item in lbgenre2.Items)
    {
        //try to get the genere from database
        var genre = _context.generes.FirstOrDefault(x => x.Name == item);    
        //if it dont exist..
        if(genre == null)
        {
            //Create it 
            genre = new Genre();
            //And set the name
            genre.Name = item;            
        }
        //but, if it already exist, you didn't create a new one, just use the existing one
        genrelist.Add(genre);
    }
