    public class Wrapper<T> : System.ComponentModel.ICustomTypeDescriptor 
        {
            public T wrappee { get; private set; }
            private Dictionary<String, Func<T, String>> ext_get;
            public Wrapper(T theObjectWeWantToWrap,Dictionary<String,Func<T,String>> theSpecsForTheAdditionalColumns)
            {
                wrappee = theObjectWeWantToWrap;
                ext_get = theSpecsForTheAdditionalColumns;
            }
    
            System.ComponentModel.AttributeCollection System.ComponentModel.ICustomTypeDescriptor.GetAttributes()
            {
                return TypeDescriptor.GetAttributes(wrappee,true);
            }
    
            string System.ComponentModel.ICustomTypeDescriptor.GetClassName()
            {
                return TypeDescriptor.GetClassName(wrappee, true);
            }
    
            string System.ComponentModel.ICustomTypeDescriptor.GetComponentName()
            {
                return TypeDescriptor.GetComponentName(wrappee, true);
            }
    
            System.ComponentModel.TypeConverter System.ComponentModel.ICustomTypeDescriptor.GetConverter()
            {
                return TypeDescriptor.GetConverter(wrappee, true);
            }
    
            System.ComponentModel.EventDescriptor System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent()
            {
                return TypeDescriptor.GetDefaultEvent(wrappee, true);
            }
    
            System.ComponentModel.PropertyDescriptor System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty()
            {
                return TypeDescriptor.GetDefaultProperty(wrappee, true);
            }
    
            object System.ComponentModel.ICustomTypeDescriptor.GetEditor(Type editorBaseType)
            {
                return TypeDescriptor.GetEditor(wrappee, editorBaseType, true);
            }
    
            System.ComponentModel.EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
            {
                return TypeDescriptor.GetEvents(wrappee, attributes, true);
            }
    
            System.ComponentModel.EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents()
            {
                return TypeDescriptor.GetEvents(wrappee, true);
            }
    
            System.ComponentModel.PropertyDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
            {
                return filterProps(TypeDescriptor.GetProperties(wrappee, attributes, true));
            }
    
            System.ComponentModel.PropertyDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetProperties()
            {
                return filterProps(TypeDescriptor.GetProperties(wrappee, true));
            }
    
            object System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner(System.ComponentModel.PropertyDescriptor pd)
            {
                if (ext_get.Keys.Contains(pd.Name))
                    return this;
                return wrappee;
            }
    
            private PropertyDescriptorCollection filterProps(PropertyDescriptorCollection propertyDescriptorCollection)
            {
                List<PropertyDescriptor> pd_list = new List<PropertyDescriptor>(propertyDescriptorCollection.Cast<PropertyDescriptor>().Where(x=>!ext_get.Keys.Contains(x.DisplayName)));
                foreach (var item in ext_get)
                {
                    pd_list.Add(new MyPropertyDescriptor<T>(item));
                }
                return new PropertyDescriptorCollection(pd_list.ToArray());
            }
            private class MyPropertyDescriptor<T> : System.ComponentModel.PropertyDescriptor 
            {
                public MyPropertyDescriptor(KeyValuePair<string,Func<T,string>>kvp)
                    :base(kvp.Key,new Attribute[]{})
                {
                    f = kvp.Value;
                }
                private Func<T, String> f;
    
                public override bool CanResetValue(object component)
                {
                    return false;
                }
    
                public override Type ComponentType
                {
                    get { return typeof(Wrapper<T>); }
                }
    
                public override object GetValue(object component)
                {
                    Wrapper<T> c = (Wrapper<T>)component;
                    return f(c.wrappee);
                }
    
                public override bool IsReadOnly
                {
                    get { return true; }
                }
    
                public override Type PropertyType
                {
                    get { return typeof(String); }
                }
    
                public override void ResetValue(object component)
                {
                    throw new NotImplementedException();
                }
    
                public override void SetValue(object component, object value)
                {
                    throw new NotImplementedException();
                }
    
                public override bool ShouldSerializeValue(object component)
                {
                    return false;
                }
            }
        }
