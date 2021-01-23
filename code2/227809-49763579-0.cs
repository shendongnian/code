    public static T TrimSingleEntity<T>(this T entity)
        {
            if (entity == null) return entity;
            var props = entity.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(prop => prop.PropertyType == typeof(string))
                    .Where(prop => prop.GetIndexParameters().Length == 0)
                    .Where(prop => prop.CanWrite && prop.CanRead);
            foreach (var prop in props)
            {
                var value = (string)prop.GetValue(entity, null);
                if (value == null) continue;
                value = value.Trim();
                prop.SetValue(entity, value, null);
            }
            return entity;
        }
    public static List<T> TrimEntityList<T>(this List<T> entityList)
        {
            foreach (var entity in entityList) TrimSingleEntity(entity);
            return entityList;
        }
