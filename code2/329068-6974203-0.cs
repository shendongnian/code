    [DataContract]
    public sealed class Test
    {
        public DetailCollection Details {get;set;}
    }
    [CollectionDataContract]
    public sealed class DetailCollection : Collection<string> {}
