static void Main( string[] args )
{
    int[] v = new int[] { 1, 2, 3 };
    int[] w = new int[] { 4, 5, 6 };
    foreach( var value in MixedSum( v, w ) )
    {
        Console.WriteLine( value );
    }
}
private static IEnumerable<int> MixedSum( int[] v, int[] w )
{
    for ( int c = 0; c < v.Length; c++ )
    {
        for ( int d = 0; d < w.Length; d++ )
        {
            yield return  v[c] + w[d];
        }
    }
}
