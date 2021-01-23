    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form { Text = "read only",
                Controls = {
                    new PropertyGrid { Dock = DockStyle.Fill, SelectedObject = new Foo { IsBarEditable = false }}
                }
            });
            Application.Run(new Form { Text = "read write",
                Controls = {
                    new PropertyGrid { Dock = DockStyle.Fill, SelectedObject = new Foo { IsBarEditable = true }}
                }
            });
        }
    
    }
    
    [TypeConverter(typeof(Foo.FooConverter))]
    class Foo
    {
        [Browsable(false)]
        public bool IsBarEditable { get; set; }
        public string Bar { get; set; }
        private class FooConverter : ExpandableObjectConverter
        {
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                var props = base.GetProperties(context, value, attributes);
                if (!((Foo)value).IsBarEditable)
                {   // swap it
                    PropertyDescriptor[] arr = new PropertyDescriptor[props.Count];
                    props.CopyTo(arr, 0);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].Name == "Bar") arr[i] = new ReadOnlyPropertyDescriptor(arr[i]);
                    }
                    props = new PropertyDescriptorCollection(arr);
                }
                return props;
            }
        }
    }
    class ReadOnlyPropertyDescriptor : ChainedPropertyDescriptor
    {
        public ReadOnlyPropertyDescriptor(PropertyDescriptor tail) : base(tail) { }
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        public override void SetValue(object component, object value)
        {
            throw new InvalidOperationException();
        }
    }
    abstract class ChainedPropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyDescriptor tail;
        protected PropertyDescriptor Tail { get {return tail; } }
        public ChainedPropertyDescriptor(PropertyDescriptor tail) : base(tail)
        {
            if (tail == null) throw new ArgumentNullException("tail");
            this.tail = tail;
        }
        public override void AddValueChanged(object component, System.EventHandler handler)
        {
            tail.AddValueChanged(component, handler);
        }
        public override AttributeCollection Attributes
        {
            get
            {
                return tail.Attributes;
            }
        }
        public override bool CanResetValue(object component)
        {
            return tail.CanResetValue(component);
        }
        public override string Category
        {
            get
            {
                return tail.Category;
            }
        }
        public override Type ComponentType
        {
            get { return tail.ComponentType; }
        }
        public override TypeConverter Converter
        {
            get
            {
                return tail.Converter;
            }
        }
        public override string Description
        {
            get
            {
                return tail.Description;
            }
        }
        public override bool DesignTimeOnly
        {
            get
            {
                return tail.DesignTimeOnly;
            }
        }
        public override string DisplayName
        {
            get
            {
                return tail.DisplayName;
            }
        }
        public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
        {
            return tail.GetChildProperties(instance, filter);
        }
        public override object GetEditor(Type editorBaseType)
        {
            return tail.GetEditor(editorBaseType);
        }
        public override object GetValue(object component)
        {
            return tail.GetValue(component);
        }
        public override bool IsBrowsable
        {
            get
            {
                return tail.IsBrowsable;
            }
        }
        public override bool IsLocalizable
        {
            get
            {
                return tail.IsLocalizable;
            }
        }
        public override bool IsReadOnly
        {
            get { return tail.IsReadOnly; }
        }
        public override string Name
        {
            get
            {
                return tail.Name;
            }
        }
        public override Type PropertyType
        {
            get { return tail.PropertyType; }
        }
        public override void RemoveValueChanged(object component, EventHandler handler)
        {
            tail.RemoveValueChanged(component, handler);
        }
        public override void ResetValue(object component)
        {
            tail.ResetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            tail.SetValue(component, value);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return tail.ShouldSerializeValue(component);
        }
        public override bool SupportsChangeEvents
        {
            get
            {
                return tail.SupportsChangeEvents;
            }
        }
    }
