    public void DoStuff( int a, string b, string c, string d )
    {
        //your code here
    }
    public void DoStuff( string e )
    {
       string[] splitE = e.Split( ',' );
       int a;
       int.TryParse( splitE[0], out a );
       DoStuff( a, splitE[1], splitE[2], splitE[3] );
    }
