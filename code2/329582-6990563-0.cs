    internal sealed class HttpSessionMock : HttpSessionStateBase
    {
        public override NameObjectCollectionBase.KeysCollection Keys
        {
            get { return _collection.Keys; }
        }
        
        private readonly NameValueCollection _collection = new NameValueCollection();
    }
