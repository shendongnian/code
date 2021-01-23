    static void Main(string[] args)
    {
        while( true )
        {
            FileChanges();
            FolderChanges();
            OutputChanges();
            Thread.Sleep( 10000 );
        }
    }
