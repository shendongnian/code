    private object FormatObject(object value)
    {
        if (this.ControlAtDesignTime())
        {
            return value;
        }
        Type propertyType = this.propInfo.PropertyType;
        if (this.formattingEnabled)
        {
            ConvertEventArgs args = new ConvertEventArgs(value, propertyType);
            this.OnFormat(args);
            if (args.Value != value)
            {
                return args.Value;
            }
            TypeConverter sourceConverter = null;
            if (this.bindToObject.FieldInfo != null)
            {
                sourceConverter = this.bindToObject.FieldInfo.Converter;
            }
            return Formatter.FormatObject(value, propertyType, sourceConverter, this.propInfoConverter, this.formatString, this.formatInfo, this.nullValue, this.dsNullValue);
        }
        ConvertEventArgs cevent = new ConvertEventArgs(value, propertyType);
        this.OnFormat(cevent);
        object obj2 = cevent.Value;
        if (propertyType == typeof(object))
        {
            return value;
        }
        if ((obj2 != null) && (obj2.GetType().IsSubclassOf(propertyType) || (obj2.GetType() == propertyType)))
        {
            return obj2;
        }
        TypeConverter converter2 = TypeDescriptor.GetConverter((value != null) ? value.GetType() : typeof(object));
        if ((converter2 != null) && converter2.CanConvertTo(propertyType))
        {
            return converter2.ConvertTo(value, propertyType);
        }
        if (value is IConvertible)
        {
            obj2 = Convert.ChangeType(value, propertyType, CultureInfo.CurrentCulture);
            if ((obj2 != null) && (obj2.GetType().IsSubclassOf(propertyType) || (obj2.GetType() == propertyType)))
            {
                return obj2;
            }
        }
        throw new FormatException(SR.GetString("ListBindingFormatFailed"));
    }
