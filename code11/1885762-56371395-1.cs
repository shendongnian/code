    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    public class StaticPropertyDescriptor : PropertyDescriptor
    {
        PropertyInfo p;
        Type owenrType;
        public StaticPropertyDescriptor(PropertyInfo pi, Type owenrType)
            : base(pi.Name,
                  pi.GetCustomAttributes().Cast<Attribute>().ToArray())
        {
            p = pi;
            this.owenrType = owenrType;
        }
        public override bool CanResetValue(object c) => false;
        public override object GetValue(object c) => p.GetValue(null);
        public override void ResetValue(object c) { }
        public override void SetValue(object c, object v) => p.SetValue(null, v);
        public override bool ShouldSerializeValue(object c) => false;
        public override Type ComponentType { get { return owenrType; } }
        public override bool IsReadOnly { get { return !p.CanWrite; } }
        public override Type PropertyType { get { return p.PropertyType; } }
    }
