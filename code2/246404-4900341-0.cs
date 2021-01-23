    class MyPropertyDescriptor : PropertyDescriptor
    {
        private static readonly Attribute[] nix = new Attribute[0];
        private readonly PropertyDescriptor parent;
        private readonly PropertyDescriptor child;
        public MyPropertyDescriptor(PropertyDescriptor parent, PropertyDescriptor child)
            : base(parent.Name + "." + child.Name, nix)
        {
            this.parent = parent;
            this.child = child;
        }
        public override object GetValue(object component)
        {
            var temp = parent.GetValue(component);
            if (temp == null) return null;
            var temp2 = child.GetValue(temp);
            return temp2;
        }
        public override Type PropertyType
        {
            get { return child.PropertyType; }
        }
        public override bool IsReadOnly
        {
            get { return true; }
        }
        public override void SetValue(object component, object value)
        {
            throw new NotSupportedException();
        }
        public override void ResetValue(object component)
        {
            throw new NotSupportedException();
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get { return parent.ComponentType; }
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
