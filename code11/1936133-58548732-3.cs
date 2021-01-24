    List<Book> books = GetBooks();
    
    StringBuilder sb = new StringBuilder();
    const Int32 maxPerLine = 2;
    Int32 longestName = books.Max( b => b.Name.Length ) + 1; // Determine the width of the column by finding the longest text in the data. `Max` is a Linq extension method. Then add 1 to ensure there's always at least 1 dot between the name and the date.
    // Render column headings:
    for( Int32 i = 0; i < maxPerLine; i++ )
    {
        sb.Append( "Book".PadRight( longestName ) );
        sb.Append( "Date".PadRight( 5 ) );
        sb.Append( "  " );
    }
    sb.AppendLine();
    // Render the book names and dates:
    Int32 i = 0;
    foreach( Book book in books ) 
    {
        if( i > 0 && i % maxPerLine == 0 ) sb.AppendLine();
        String namePadded = book.Name.PadRight( longestName + 1, '.' ); // +1 
        sb.Append( namePadded );
        sb.Append( book.CompletedDate.ToString("MM-yy") );
        sb.Append( "  " );
        i++;
    }
