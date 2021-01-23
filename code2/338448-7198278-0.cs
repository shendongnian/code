    public class ExternalProperty<PropertyType>
    {
        delegate PropertyType GetFunction();
        delegate void SetFunction(PropertyType value);
        GetFunction GetValue;
        SetFunction SetValue;
        public ExternalProperty(PropertyInfo externalProperty)
        {
            MethodInfo getMethod = externalProperty.GetGetMethod();
            GetFunction getter = (GetFunction)Delegate.CreateDelegate(typeof(GetFunction), getMethod);
            MethodInfo setMethod = externalProperty.GetSetMethod();
            SetFunction setter = (SetFunction)Delegate.CreateDelegate(typeof(SetFunction), setMethod);
        }
        public PropertyType Value
        {
            get { return GetValue(); }
            set
            {
                SetValue(value);
            }
        }
    }
