    public object GetValue(string name, Type type)
    {
        Type type3;
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        RuntimeType castType = type as RuntimeType;
        if (castType == null)
        {
            throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
        }
        object element = this.GetElement(name, out type3);
        if (RemotingServices.IsTransparentProxy(element))
        {
            if (RemotingServices.ProxyCheckCast(RemotingServices.GetRealProxy(element), castType))
            {
                return element;
            }
        }
        else if ((object.ReferenceEquals(type3, type) || type.IsAssignableFrom(type3)) || (element == null))
        {
            return element;
        }
        return this.m_converter.Convert(element, type);
    }
