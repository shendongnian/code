    using System.Diagnostics;
    using ProtoBuf;
    [ProtoContract]
    [ProtoInclude(1, typeof(ValueA))]
    [ProtoInclude(2, typeof(ValueB))]
    public class Value
    {
    }
    
    [ProtoContract]
    public class ValueA : Value
    {
    }
    
    [ProtoContract]
    public class ValueB : Value
    {
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(Container<ValueA>))]
    [ProtoInclude(2, typeof(Container<ValueB>))]
    public abstract class Container
    {
    
        public abstract Value BaseValue { get; set; }
    }
    [ProtoContract]
    public class Container<T> : Container where T : Value
    {
        [ProtoMember(1)]
        public T Value { get; set;}
    
        public override Value BaseValue
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
