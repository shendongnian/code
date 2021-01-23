    foreach (object publication in pubs)
    {
       var book = publication as Book;
       var magazine = publication as Magazine;
       if (book != null) {
         //it's a book, do your thing
       } else if (magazine != null) {
         //it's a magazine, do your thing
       } else {
        throw new InvalidOperationException(publication.GetType().Name + " is not a book or magazine: ");
       }
    }
