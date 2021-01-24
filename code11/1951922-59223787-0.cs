        public static string GetStatusField<T>(this T type) where T : Type
        {
            PropertyInfo propertyInfo = type.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(StatusFieldAttribute))).FirstOrDefault();
            if (propertyInfo == null)
            {
                Log.Error($"StatusFieldAttribute not found in {type.Name} ");
                throw new Exception($"StatusFieldAttribute not found in { type.Name } ");
            }
            else
                return propertyInfo.Name;
        }
