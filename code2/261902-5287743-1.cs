    public abstract class Relation
    {
        internal Relation(object subject, object obj)
        {
            Subject = subject;
            Object = obj;
        }
        public object Subject { get; private set; }
        public object Object { get; private set; }
    }
    public sealed class LessThanRelation : Relation
    {
        public LessThanRelation(object subject, object obj) : base(subject, obj) { }
    }
    public sealed class EqualToRelation : Relation
    {
        public EqualToRelation(object subject, object obj) : base(subject, obj) { }
    }
    public sealed class GreaterThanRelation : Relation
    {
        public GreaterThanRelation(object subject, object obj) : base(subject, obj) { }
    }
