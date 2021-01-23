using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace ConsoleApplication1
{
    internal sealed class MyCoolPropertyDescriptor : PropertyDescriptor
    {
        private Func&lt;object, object&gt; propertyGetter;
        private Action&lt;object, object&gt; propertySetter;
        public MyCoolPropertyDescriptor(
            string name,
            Func&lt;object, object&gt; propertyGetter,
            Action&lt;object, object&gt; propertySetter)
            : base(name, new Attribute[] {})
        {
            this.propertyGetter = propertyGetter;
            this.propertySetter = propertySetter;
        }
        public override bool CanResetValue(object component)
        {
            return true;
        }
        public override System.Type ComponentType
        {
            get { return typeof(object); }
        }
        public override object GetValue(object component)
        {
            return this.propertyGetter(component);
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override System.Type PropertyType
        {
            get { return typeof(object); }
        }
        public override void ResetValue(object component)
        {
            this.propertySetter(component, null);
        }
        public override void SetValue(object component, object value)
        {
            this.propertySetter(component, value);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
    public sealed class Info : CustomTypeDescriptor
    {
        IDictionary&lt;string, object&gt; properties;
        public Info(IDictionary&lt;string, object&gt; properties)
        {
            this.properties = properties;
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            var orig = base.GetProperties();
            var newProps = this.properties
                .Select(kvp =&gt; new MyCoolPropertyDescriptor(
                    kvp.Key,
                    o =&gt; ((Info)o).properties[kvp.Key],
                    (o, v) =&gt; ((Info)o).properties[kvp.Key] = v));
            return new PropertyDescriptorCollection(orig
                .Cast&lt;PropertyDescriptor&gt;()
                .Concat(newProps)
                .ToArray());
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var info = new Info(new Dictionary&lt;string, object&gt;{{"some_property", 5}});
            var prop = TypeDescriptor.GetProperties(info)["some_property"];
            var val = prop.GetValue(info); //should return 5
            Console.WriteLine(val);
        }
    }
}
