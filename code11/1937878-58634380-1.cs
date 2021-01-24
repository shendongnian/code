    [TypeConverter(typeof(KeyConverter<DogKey>))]
    public struct DogKey : IEquatable<DogKey>
    {
        public DogKey(int id)
        {
            Id = id;
        }
        public int Id { get; }
        #region IEquatable implementation
        #endregion IEquatable implementation
    }
    [TypeConverter(typeof(KeyConverter<CatKey>))]
    public struct CatKey : IEquatable<CatKey>
    {
        public CatKey(int id)
        {
            Id = id;
        }
        public int Id { get; }
        #region IEquatable implementation
        #endregion IEquatable implementation
    }
