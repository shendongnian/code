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
    
            var bag = new BasicPropertyBag { Properties = {
                new MetaProp("Name", typeof(string)),
                new MetaProp("Description", typeof(string)),
                new MetaProp("DateOfBirth", typeof(DateTime)
                    , new CategoryAttribute("Personal"), new DisplayNameAttribute("Date Of Birth"))
            } };
            bag["Name"] = "foo";
            bag["DateOfBirth"] = DateTime.Today;
            Application.Run(new Form { Controls = { new PropertyGrid { Dock = DockStyle.Fill, SelectedObject = bag } } });
        }
    }
    
    public class MetaProp
    {
        public MetaProp(string name, Type type, params Attribute[] attributes)
        {
            this.Name = name;
            this.Type = type;
            if (attributes != null)
            {
                Attributes = new Attribute[attributes.Length];
                attributes.CopyTo(Attributes, 0);
            }
        }
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public Attribute[] Attributes { get; private set; }
    }
    
    [TypeConverter(typeof(BasicPropertyBagConverter))]
    class BasicPropertyBag
    {
        
        private readonly List<MetaProp> properties = new List<MetaProp>();
        public List<MetaProp> Properties { get { return properties; } }
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();
    
        public object this[string key]
        {
            get { object value; return values.TryGetValue(key, out value) ? value : null; }
            set { if (value == null) values.Remove(key); else values[key] = value; }
        }
    
        class BasicPropertyBagConverter : ExpandableObjectConverter
        {
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                PropertyDescriptor[] metaProps = (from prop in ((BasicPropertyBag)value).Properties
                                                  select new PropertyBagDescriptor(prop.Name, prop.Type, prop.Attributes)).ToArray();
                return new PropertyDescriptorCollection(metaProps);
            }
        }
        class PropertyBagDescriptor : PropertyDescriptor
        {
            private readonly Type type;
            public PropertyBagDescriptor(string name, Type type, Attribute[] attributes)
                : base(name, attributes) {
                this.type = type;
            }
            public override Type PropertyType { get { return type; } }
            public override object GetValue(object component) { return ((BasicPropertyBag)component)[Name]; }
            public override void SetValue(object component, object value) { ((BasicPropertyBag)component)[Name] = (string)value; }
            public override bool ShouldSerializeValue(object component) { return GetValue(component) != null; }
            public override bool CanResetValue(object component) { return true; }
            public override void ResetValue(object component) { SetValue(component, null); }
            public override bool IsReadOnly { get { return false; } }
            public override Type ComponentType { get { return typeof(BasicPropertyBag); } }
        }
    
    }
