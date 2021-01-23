    // generated proxy .cs
    [DataContract]
    partial class SearchResult
    {
        ...
    }
    // hand-written .cs
    [KnownType(typeof(Subclass1InSharedAssembly)), etc.]
    partial class SearchResult
    {
        // Now the client knows how to deserialise derived types.
    }
