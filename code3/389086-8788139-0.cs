    public override TypeConverter Converter
    {
        get
        {
            var converter = base.Converter;
            // If the property of the class is a interface, the default implementation
            // of PropertyDescriptor will return a ReferenceConverter, but that doesn't
            // work as expected (normally the right site will stay empty).
            // Instead we'll return a TypeConverter, that works on the concrete type
            // and returns at least the ToString() result of the given type.
            if (_OriginalPropertyDescriptor.PropertyType.IsInterface)
            {
                if (converter.GetType() == typeof(ReferenceConverter))
                {
                    converter = _InterfaceConverter;
                }
            }
            return converter;
        }
    }
