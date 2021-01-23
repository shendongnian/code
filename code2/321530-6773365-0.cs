        public static int MaxId<T>(this DbLinq.Data.Linq.Table<T> table) where T : class
        {
            var param = Expression.Parameter(typeof(T), "p");
            var body = Expression.PropertyOrField(param, "ID");
            var lambda = Expression.Lambda<Func<T, int>>(body, param);
            var val = table.OrderByDescending(lambda).FirstOrDefault();
            return Convert.ToInt32(val.GetType().GetProperty("ID").GetGetMethod().Invoke(val, null));
        }
