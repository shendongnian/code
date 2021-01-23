    public abstract class BaseClass
    {
        public bool MyBool { get { return MyBoolInternal; } }
        protected abstract bool MyBoolInternal { get; set; }
    }
    public class ChildClass : BaseClass
    {
        protected override bool MyBoolInternal { get; set; }
    }
