        public static object GetDr<T>(this DataRow row, string field)
        {
            // might want to throw some type checking to make 
            // sure row[field] is the same type as T
            if (typeof(T).IsValueType)
            {
                Type nullableType = typeof(Nullable<>).MakeGenericType(typeof(T));
                if (row.IsNull(field))
                    return Activator.CreateInstance(nullableType);
                else
                    return Activator.CreateInstance(nullableType, new[] { row[field] });
            }
            else
            {
                return row[field];
            }
        }
