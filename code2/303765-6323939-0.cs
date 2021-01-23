    public void CopyValues<TSource, TTarget>(TSource source, TTarget target)
    {
        var sourceProperties = typeof(TSource).GetProperties().Where(p => p.CanRead);
        foreach (var property in sourceProperties)
        {
            var targetProperty = typeof(TTarget).GetProperty(property.Name);
            if (targetProperty != null && targetProperty.CanWrite && targetProperty.PropertyType.IsAssignableFrom(property.PropertyType))
            {
                var value = property.GetValue(source, null);
                targetProperty.SetValue(target, value, null);
            }
        }
    }
