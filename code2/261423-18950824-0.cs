    public static IEnumerable<Tuple<int, double>> LocalMaxima( IEnumerable<double> source, int windowSize )
    {
        // Round up to nearest odd value
        windowSize = windowSize - windowSize % 2 + 1;
        int halfWindow = windowSize / 2;
        int index = 0;
        var before = new Queue<double>( Enumerable.Repeat( double.NegativeInfinity, halfWindow ) );
        var after = new Queue<double>( source.Take( halfWindow + 1 ) );
        foreach( double d in source.Skip( halfWindow + 1 ).Concat( Enumerable.Repeat( double.NegativeInfinity, halfWindow + 1 ) ) )
        {
            double curVal = after.Dequeue();
            if( before.All( x => curVal > x ) && after.All( x => curVal >= x ) )
            {
                yield return Tuple.Create( index, curVal );
            }
            before.Dequeue();
            before.Enqueue( curVal );
            after.Enqueue( d );
            index++;
        }
    }
