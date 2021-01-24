    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    public class CustomObjectWrapper : CustomTypeDescriptor
    {
        public object WrappedObject { get; private set; }
        private IEnumerable<PropertyDescriptor> staticProperties;
        public CustomObjectWrapper(object o)
            : base(TypeDescriptor.GetProvider(o).GetTypeDescriptor(o))
        {
            WrappedObject = o;
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var instanceProperties = base.GetProperties(attributes)
                .Cast<PropertyDescriptor>();
            staticProperties = WrappedObject.GetType()
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Select(p => new StaticPropertyDescriptor(p, WrappedObject.GetType()));
            return new PropertyDescriptorCollection(
                instanceProperties.Union(staticProperties).ToArray());
        }
    }
