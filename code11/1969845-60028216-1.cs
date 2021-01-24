cs
Random rng = new Random(); // System.Random
List<(double random, int value)> values = new List<(double random, int value)>(); // list for shuffling
for ( int i = 0; i < 16; i++ ) {
    values.Add( ( rng.NextDouble(), i + 1 ) ); // random position and the value
}
values.Sort( ( a, b ) => b.random - a.random ); // sort using the random position. Note : Sort is a System.Linq extension method
int[,] matrix = new int[4,4];
for ( int i = 0; i < values.length; i++ ) {
    matrix[ i % 4, i / 4 ] = values[ i ].value; // populate the matrix
    // i % 4 just loops i between 0 and 3
    // i / 4 divides i by 4 and rounds DOWN, ie. increases by 1 each 4
}
