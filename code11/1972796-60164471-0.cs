    protected virtual void WriteFile ( string fileName, string content )
    {
        string directoryName = Path.GetDirectoryName ( fileName );
        if ( Directory.Exists( directoryName ) == false )
        {
            Directory.CreateDirectory ( directoryName );
        }
        // ensure consistent line ending
        using ( var sw = new StreamWriter ( fileName ) )
        {
            foreach (line in content.Split('\n')) sw.WriteLine(line.Trim('\r'));
        }
    }
