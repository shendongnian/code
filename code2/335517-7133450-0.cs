    var items = new List<string>();
    using( var stream = File.OpenRead( somePath ) )  // open file
    using( var reader = new TextReader( stream ) )   // read the stream with TextReader
    {
        string line;
        
        // read until no more lines are present
        while( (line = reader.ReadLine()) != null )
        {
            items.Add( line );
        }
    }
    
    // add the ListBox items in a bulk update instead of one at a time.
    listBox.AddRange( items );
