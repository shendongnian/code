     public static IEnumerable<T> GetEntity<T>() where T : new ()
        {
            using (SqlDataReader reader ...)
            {
                while (reader.Read())
                {
                     T t = new T();
                     var values = new object[reader.FieldCount];
                     reader.GetValues(values);
                     for (var i = 0; i < values.Length; i++)
                     {
                         t.GetType().GetProperty(reader.GetName(i)).SetValue(t, values[i], null);
                     }
                     yield return t;
                }
            }
        }
