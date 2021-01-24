 c#
using System;
class Foo
{
    public NotImplementedIterator GetEnumerator()
        => new NotImplementedIterator();
}
class NotImplementedIterator
{
    public bool MoveNext() => throw new NotImplementedException();
    public ref int Current => throw new NotImplementedException();
}
static class Program
{
    static void Main()
    {
        var obj = new Foo();
        foreach(ref int x in obj)
        {
            x = 42; // this assigns **via the ref**
        }
    }
}
So: what you're talking about *is possible right now*. Because it is assigning *via a reference*, this can push changes directly into the underlying source.
It just ... isn't very common because *that isn't what people expect when iterating over data*.
1. they only *expect* to be able to read
2. iterators are common on **immutable** data
3. the existing interfaces only support the read concept
4. it requires functionality like `ref`-return which is not well understood by most developers *and* which cannot be used from all .NET languages
5. ref return *is only sensible in some small set of scenarios*
