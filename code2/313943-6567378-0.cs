    void Main( string[] args )
    {
        var numbers = new List<int>();
        while(whatever)
        {
            var input = Console.ReadLine();
            var lines = input.Split( ' ' );
            foreach( var line in lines )
            {
                int result;
                if( !int.TryParse( line, out result ) )
                {
                    // error handling
                    continue;
                }
    
                numbers.Add( result );
            }
        }
    }
