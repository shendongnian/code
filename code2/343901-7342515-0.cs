    keyWords = new List<string> { /* some number of keywords to match */ };
    var bldr = new StringBuilder();
    // loop through all but the last string to avoid
    // a trailing '|' character.
    foreach( var s in keyWords.Take( keyWords.Count - 1 ) )
    {
        bldr.AppendFormat( "{0}|", s );
    }
    // get the last one, don't add a '|'
    bldr.Append( keyWords.Last() );
    
    var reg = new RegEx( bldr.ToString() );
