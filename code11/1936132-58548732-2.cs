    List<Book> books = GetBooks();
    
    StringBuilder sb = new StringBuilder();
    const Int32 maxPerLine = 2;
    Int32 longestName = books.Max( b => b.Name.Length ); // Determine the width of the column by finding the longest text in the data. `Max` is a Linq extension method.
    Int32 i = 0;
    foreach( Book book in books ) 
    {
        if( i > 0 && i % maxPerLine == 0 ) sb.AppendLine();
        String namePadded = book.Name.PadRight( longestName, '.' );
        sb.Append( namePadded );
        sb.Append( book.CompletedDate.ToString("MM-yy") );
        sb.Append( "  " );
        i++;
    }
