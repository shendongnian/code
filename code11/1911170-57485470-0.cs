    public abstract class Text{
        public string Value { get; }
        public Text(string val) {
            if (val.Length > MAX) throw new Exception();
            Value = val;
        }
        protected abstract int MAX{get;}
    }
    public class Name : Text{
        public Name(string val): base(val) { }
        protected override int MAX => 50;
    }
    public class Description : Text
    {
        public Description(string val) : base(val) { }
        protected override int MAX => 1000;
    }
