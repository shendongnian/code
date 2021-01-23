    public object Map(object source, Type sourceType, Type destinationType)
    {
        if (source is IEnumerable)
        {
            IEnumerable<object> input = ((IEnumerable)source).OfType<object>();
            Array a = Array.CreateInstance(destinationType.GetElementType(), input.Count());
            int index = 0;
            foreach (object data in input)
            {
                a.SetValue(AutoMap(data, data.GetType(), destinationType.GetElementType()), index);
                index++;
            }
            return a;
        }
        return AutoMap(source, sourceType, destinationType);
    }
