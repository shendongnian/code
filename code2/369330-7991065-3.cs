    foreach (var publication in pubs.OfType<IPublication>())
    {
      // publication is either a book or magazine, we don't care we are just interested in the common properties
      Console.WriteLine("{0} costs {1}",  publication.Title, publication.Price);
    }
