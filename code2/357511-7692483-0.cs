    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        // this calls the IEnumerator<Foo> GetEnumerator method
        // as explicit method implementations aren't used for method resolution in C#
        // polymorphism (IEnumerator<T> implements IEnumerator)
        // ensures this is type-safe
        return GetEnumerator();
    }
