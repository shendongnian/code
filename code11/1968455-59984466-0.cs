    public static TResult Deserialize<TResult, TItemType>() where TResult : class
    {
        if (inputStream.EndOfStream) return default(TResult);
    
        if (typeof(TResult).IsEnumerable())
        {
            var list = new List<object>();
    
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
    
            return typeof(TResult).IsArray
                ? list.Cast<TItemType>().ToArray() as TResult
                : list.Cast<TItemType>().ToList() as TResult;
        }
        ...
    }
