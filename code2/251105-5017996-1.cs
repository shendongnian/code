        /// <summary>
        /// Gets the non null value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="strict">if set to <c>true</c> [strict].</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static T GetNonNullValue<T>(this object item, T defaultValue, bool strict) {
            if(item.IsNullOrEmpty() || item == DBNull.Value) {
                return defaultValue;
            }
            var originalType = item.GetType();
            var targetType = typeof(T);
            if(originalType == targetType || originalType.IsSubclassOf(targetType)) {
                return (T)item;
            }
            TypeConverter typeConverter = TypeDescriptor.GetConverter(targetType);
            if(typeConverter.CanConvertFrom(originalType)) {
                return (T)typeConverter.ConvertFrom(item);
            }
            typeConverter = TypeDescriptor.GetConverter(originalType);
            if(typeConverter.CanConvertTo(targetType)) {
                return (T)typeConverter.ConvertTo(item, targetType);
            }
            if(strict) {
                throw new QIGException("Conversion from {0} to {1} failed!", originalType, targetType);
            }
            return defaultValue;
        }
