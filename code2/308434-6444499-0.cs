    [ServiceContract]
    interface ISearch
    {
        [OperationContract]
        SearchResult Search(SearchQuery query);
    }
    [DataContract]
    [KnownType(typeof(Subclass1InSharedAssembly)), etc...]
    class SearchResult
    {
        [DataMember]
        BaseClassDeclaredInSharedAssembly Value { get; set; }
    }
