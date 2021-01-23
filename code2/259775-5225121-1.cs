    var books = (
            from b in db.BOOKs
            let author = (from a in db.PEOPLEs
                          where b.AUTHOR == a.ID
                          select a)
            select new
            {
                ID = b.ID,
                NAME = b.Name,
                Author = author.First()
            }
        ).ToList();    
    
    foreach(var x in books)
    {
    	string AuthorName = x.Author.USER_ID;
    	//Do other stuff
    }
