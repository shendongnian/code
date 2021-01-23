    private void FindReferences( List<string> output, string searchPath, string searchString )
    {
        if ( Directory.Exists( searchPath ) )
        {																 
            var references = from file in Directory.GetFiles( searchPath, "*.*", SearchOption.AllDirectories )
                             from line in File.ReadLines( file )
                             where line.Contains( searchString, StringComparison.OrdinalIgnoreCase )
                             select new
                             {
                                 File = file,
                                 Line = line
                             };
            foreach ( var reference in references )
            {
                output.Add( string.Format( "{0}:{1}", reference.File, reference.Line ) );
            }
        }
    }
