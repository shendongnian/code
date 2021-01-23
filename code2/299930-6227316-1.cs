    IEnumerable<int> ints = ...;
    using (var disposableA = new DisposableObjectA())
    using (var disposableB = new DisposableObjectB())
    using (var disposableC = new DisposableObjectC())
    foreach (int i in ints)
    {
        // Work with disposableA, disposableB, disposableC, and i.
    }
