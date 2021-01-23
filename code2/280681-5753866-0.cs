    public static class TypeConversion {
        public static Object Convert(Object source, Type targetType) {
            var sourceType = source.GetType();
            if (targetType.IsAssignableFrom(sourceType))
                return source;
            var sourceConverter = TypeDescriptor.GetConverter(source);
            if (sourceConverter.CanConvertTo(targetType))
                return sourceConverter.ConvertTo(null, CultureInfo.InvariantCulture, source, targetType);
            var targetConverter = TypeDescriptor.GetConverter(targetType);
            if (targetConverter.CanConvertFrom(sourceType))
                return targetConverter.ConvertFrom(null, CultureInfo.InvariantCulture, source);
            throw new ArgumentException("Neither the source nor the target has a TypeConverter that supports the requested conversion.");
        }
        public static TTarget Convert<TTarget>(object source) {
            return (TTarget)Convert(source, typeof(TTarget));
        }
    }
