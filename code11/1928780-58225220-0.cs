public class AggregateEnumerable<T> : IEnumerable<T> {
    private readonly IEnumerable<T>[] _sources;
    public AggregateEnumerable( params IEnumerable<T>[] sources ) {
        _sources = sources;
    }
    public IEnumerator<T> GetEnumerator() {
        foreach( var source in _sources ) {
            var enumerator = source.GetEnumerator();
            while( enumerator.MoveNext() )
                yield return enumerator.Current;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
And then you would use it like 
var firstEnumerable = new[] { "Peter", "John" };
var secondEnumerable = new[] { "Thomas", "George" };
var myEnum = new AggregateEnumerable<string>(firstEnumerable, secondEnumerable);      
foreach( var value in myEnum )
    Console.WriteLine(value);
