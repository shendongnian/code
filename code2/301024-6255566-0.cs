    public string RemoveTrueRows( string csvFile )
    {
        var sr = new StreamReader( csvFile );
        var line = string.Empty;
        var contentsWithoutTrueRows = string.Empty;
        while ( ( line = sr.ReadLine() ) != null )
        {
            var columns = line.Split( ',' );
            if ( columns[ columns.Length - 1 ] == "True" )
            {
                contentsWithoutTrueRows += line;
            }
        }
        sr.Close();
 
        return contentsWithoutTrueRows;
    }
