    public static TResult Deserialize<TResult>(StreamReader inputStream) where TResult : class
    {
        if (inputStream.EndOfStream) return default(TResult);
        if (typeof(TResult).IsEnumerable())
        {
            Type itemType = typeof(TResult).GetItemType();
            var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));
            MethodInfo deserializeMethod = 
                typeof(SimpleFixedWidthSerializer)
                    .GetMethod("Deserialize", new[] { typeof(StreamReader) })
                    .MakeGenericMethod(new[] { itemType });
            object item = null;
            do
            {
                item = deserializeMethod.Invoke(null, new[] { inputStream });
                if (item != null)
                    list.Add(item);
            } while (item != null);
            list.Dump();
            return list.ToArray() as TResult;
        }
        ...
    }
