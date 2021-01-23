    [Serializable]
    public class StateContainer : Hashtable, IStateContainer
    {
        public StateContainer() : base() { }
        public StateContainer(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
