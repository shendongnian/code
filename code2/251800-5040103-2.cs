    static async Task<int> Func( int n )
    {
        int result;
        try
        {
            Func<Task<int>> helperLambda = async() => {
                Console.WriteLine( "    Func: Begin #{0}", n );
                await TaskEx.Delay( 100 );
                Console.WriteLine( "    Func: End #{0}", n );        
                return 0;
            };
            result = await helperLambda();
        }
        finally
        {
            Console.WriteLine( "    Func: Finally #{0}", n );
        }
        // since Func(...)'s return statement is outside the try/finally,
        // the finally body is certain to execute first, even in face of this bug.
        return result;
    }
