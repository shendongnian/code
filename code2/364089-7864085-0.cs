        public interface IPrimaryKeyed
        {
            object ObjId { get; }
        }
        public abstract class PrimaryKeyed<TKey> : IPrimaryKeyed
        {
            public object ObjId { get { return Id; } }
            public abstract TKey Id { get; }
        }
    ---
    public override string ToString()
    {
        string result = _businessObject.GetType().Name;
        var keyed = _businessObject as IPrimaryKeyed;
        if (keyed != null)
        {
            result += " " + keyed.ObjId.ToString();
        }
        return result;
    }
