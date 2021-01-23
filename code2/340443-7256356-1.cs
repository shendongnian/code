    public int getListSize()
    {
        Type type = typeof(T);
        if (type.IsEnum)
        {
            return this.Sum(item => Marshal.SizeOf(Enum.GetUnderlyingType(type)));
        }
        if (type.IsValueType)
        {
            return this.Sum(item => Marshal.SizeOf(item));
        }
        if (type == typeof(string))
        {
            return this.Sum(item => Encoding.Default.GetByteCount(item.ToString()));
        }
        return 32 * this.Count;
    }
