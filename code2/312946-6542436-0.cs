    private string CheckMeOut<T>( T something )
    {
        return something.GetType().Name;
    }
	
    public void CheckMeOutTest( )
    {
        var anon = ( from x in typeof(string).GetMethods( )
	                 select new {x.Name, Returns = x.ReturnType.Name} ).First( );
        string s = CheckMeOut( anon );
        Console.Out.WriteLine( s );
    }
