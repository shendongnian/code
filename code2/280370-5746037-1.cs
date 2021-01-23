    [AttributeUsage(AttributeTargets.Class, Inheritable = true)]
    public class InfoAttribute : Attribute
    {
        public InfoAttribute(string info) { this.Info = info; }
        public string Info { get; private set; }
    }
    [InfoAttribute(Info = "From Base")]
    public class Base
    {
        public string GetInfo()
        {
            var attr = GetType()
                .GetCustomAttributes(typeof(InfoAttribute), true)
                .FirstOrDefault();
            return (attr == null) ? null : attr.Info;
        }
    }
    [InfoAttribute(Info = "From A")]
    public class A : Base { }
