    public Matrix(int width, IEnumerable<T> values)
    {
        if (values.Count() % width != 0)
            throw new ArgumentException("values parameter is indivisible by width");
        int last = 0;
        for (int i = width; i <= values.Count(); i += width)
        {
            Add(values.Skip(last).Take(width))
            last = i;
        }
    }
