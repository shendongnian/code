    private static object Convert(string value, Type targetType)
    {
        if (targetType == typeof(double))
            return XmlConvert.ToDouble(value);
        …
        throw new ArgumentException();
    }
    …
    case CriteriaOperator.Equal:
        return x => object.Equals(
            Convert(x.Attribute(criterion.PropertyName).Value, typeof(T)),
            criterion.PropertyValue);
