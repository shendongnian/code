    void HandleCollection (IEnumerable<object> collection)
    {
        // ...
    }
    var ints = new List<int> { 1, 2, 3 }
    // IEnumerable is defined as IEnumerable<out T> in .NET 4.0
    // 'out' keyword guarantees that T is only used for return values
    // and therefore client code can't explode the universe   
    var intsAsObjs = (IEnumerable<object>) ints;
    HandleCollection (intsAsObjs);
