        /// <summary>
        /// returns the attribute for a given enum
        /// </summary>        
        public static TAttribute GetAttribute<TAttribute>(IConvertible @enum)
        {
            TAttribute attributeValue = default(TAttribute);
            if (@enum != null)
            {
                FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
                attributeValue = fi == null ? attributeValue : (TAttribute)fi.GetCustomAttributes(typeof(TAttribute), false).DefaultIfEmpty(null).FirstOrDefault();
            }
            return attributeValue;
        }
