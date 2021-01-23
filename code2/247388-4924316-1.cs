    void HandleCollection (IEnumerable<object> collection)
    {
        // ...
    }
    var words = new List<string> { "Serve God", "love me", "mend" };
    // IEnumerable is defined as IEnumerable<out T> in .NET 4.0
    // 'out' keyword guarantees that T is only used for return values
    // and therefore client code can't explode the universe   
    var objects = (IEnumerable<object>) words;
    HandleCollection (objects);
