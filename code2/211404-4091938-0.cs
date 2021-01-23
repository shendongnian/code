    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            var bag = new BasicPropertyBag { Properties = { "Name", "Description" } };
            bag["Name"] = "foo";
            Application.Run(new Form { Controls = { new PropertyGrid { Dock = DockStyle.Fill, SelectedObject = bag } } });
        }
    }
    
    [TypeConverter(typeof(BasicPropertyBagConverter))]
    class BasicPropertyBag
    {
        private readonly List<string> properties = new List<string>();
        public List<string> Properties { get { return properties; } }
        private readonly Dictionary<string, string> values = new Dictionary<string, string>();
    
        public string this[string key]
        {
            get { string value; return values.TryGetValue(key, out value) ? value : null; }
            set { if (value == null) values.Remove(key); else values[key] = value; }
        }
    
        class BasicPropertyBagConverter : ExpandableObjectConverter
        {
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                PropertyDescriptor[] metaProps = (from prop in ((BasicPropertyBag)value).Properties
                                                  select new PropertyBagDescriptor(prop)).ToArray();
                return new PropertyDescriptorCollection(metaProps);
            }
        }
        class PropertyBagDescriptor : PropertyDescriptor
        {
            private static readonly Attribute[] nix = new Attribute[0];
            public PropertyBagDescriptor(string name) : base(name, nix) { }
            public override Type PropertyType { get { return typeof(string); } }
            public override object GetValue(object component) { return ((BasicPropertyBag)component)[Name]; }
            public override void SetValue(object component, object value) { ((BasicPropertyBag)component)[Name] = (string)value; }
            public override bool ShouldSerializeValue(object component) { return GetValue(component) != null; }
            public override bool CanResetValue(object component) { return true; }
            public override void ResetValue(object component) { SetValue(component, null); }
            public override bool IsReadOnly { get { return false; } }
            public override Type ComponentType { get { return typeof(BasicPropertyBag); } }
        }
    
    }
