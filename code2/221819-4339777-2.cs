And idea to use [OnDeserialized] Attribute on some method, that builds up all other properies. And here is example:
    [Serializable]
    public class TestClass : ISerializable
    {
        private Trade[] _innerList;
        public ObservableCollection<Trade> List { get; set; }
        public TestClass()
        { }
        [OnDeserialized]
        private void SetValuesOnDeserialized(StreamingContext context)
        {
            this.List = new ObservableCollection<Trade>(_innerList);
            this._innerList = null;
        }
        protected TestClass(SerializationInfo info, StreamingContext context)
        {
            var value = info.GetValue("inner", typeof(Trade[]));
            this._innerList = (Trade[])value;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("inner", this.List.ToArray());
        }
    }
