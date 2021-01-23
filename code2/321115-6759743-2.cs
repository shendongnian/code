    private void FindReferences( List<string> output, string searchPath, string searchString )
    {
        if ( Directory.Exists( searchPath ) )
        {																 
            string[] files = Directory.GetFiles( searchPath, "*.*", SearchOption.AllDirectories );
            string line;
            // Loop through all the files in the specified directory & in all sub-directories
            foreach ( string file in files )
            {
                using ( StreamReader reader = new StreamReader( file ) )
                {
                    int lineNumber = 1;
                    while ( ( line = reader.ReadLine() ) != null )
                    {
                        if ( line.Contains( searchString, StringComparison.OrdinalIgnoreCase ) )
                        {
                            output.Add( string.Format( "{0}:{1}", file, lineNumber ) );
                        }
                        lineNumber++;
                    }
                }					
            }
        }
    }
