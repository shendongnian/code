    static void Main()
    {
        WriteGenericArgumentType( new Action<string>( s => { } ) );
        WriteGenericArgumentType( new Action<object>( o => { } ) );
    }
    
    static void WriteGenericArgumentType( Action<string> action )
    {
        Console.WriteLine( DiscoverGenericArgumentType( Wrap( action ) ).Name );
    }
    
    static Type DiscoverGenericArgumentType( Delegate action )
    {
        return action.GetType().GetGenericArguments()[ 0 ];
    }
    
    static Action<T> Wrap<T>( Action<T> action )
    {
        return new Action<T>( o => action( o ) );
    }
