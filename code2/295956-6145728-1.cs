    using System.Diagnostics;
    using ProtoBuf;
    
    [ProtoContract]
    public class ValueA
    {
    }
    
    [ProtoContract]
    public class ValueB
    {
    }
    
    [ProtoContract]
    [ProtoInclude(1, typeof(Container<ValueA>))]
    [ProtoInclude(2, typeof(Container<ValueB>))]
    public abstract class Container
    {
    
        public abstract object BaseValue { get; set; }
    }
    [ProtoContract]
    public class Container<T> : Container
    {
        [ProtoMember(1)]
        public T Value { get; set;}
    
        public override object BaseValue
        {
            get { return Value; }
            set { Value = (T)value; }
        }
    }
    
    static class Program
    {
        static void Main()
        {
            var model = new Container<ValueA>();
            model.Value = new ValueA();
            var clone = Serializer.DeepClone(model);
            Debug.Assert(clone.Value is ValueA);
        }
    }
