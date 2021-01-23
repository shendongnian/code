    void PrintInner( string output, float total, List<KeyValuePair<string, float>> children )
    {
        var parent = children[0];
        var innerChildren = new List<KeyValuePair<string, float>>();
        innerChildren.AddRange( children );
        innerChildren.Remove( parent );
        
        output += parent.Key + ":" + parent.Value.ToString();
        total += parent.Value;
        
        if( output != "" ) // Will prevent outputting "Group1:10 = 10", comment out if desired.
            Console.WriteLine( output + " = " + total.ToString() );
        output += " + ";
    
        while( innerChildren.Count > 0 )
        {
            PrintInner( output, total, innerChildren );
            innerChildren.RemoveAt( 0 );
        }
    
    }
    
    
    void PrintAll()
    {
        var items = new List<KeyValuePair<string,float>>()
        {
            new KeyValuePair<string,float>>( "Group1", 10 ),
            new KeyValuePair<string,float>>( "Group2", 15 ),
            new KeyValuePair<string,float>>( "Group3", 20 ),
            new KeyValuePair<string,float>>( "Group4", 30 )
        }
    
        while( items.Count > 0 )
        {
            PrintInner( "", 0, items );
            items.RemoveAt( 0 );
        }
    }
