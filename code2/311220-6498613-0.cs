    [ProtoContract]
    [ProtoInclude(4, typeof(Column<int>))] // etc
    abstract class Column {
        [ProtoMember(1)]
        public string Name {get;private set;}
        public abstract object Value {get;private set;}
    }
    [ProtoContract]
    class Column<T> : Column {
        [ProtoMember(1)]
        public T TypedValue { get;private set;}
        override Value {...shim to TypedValue...}
    }
    // etc
