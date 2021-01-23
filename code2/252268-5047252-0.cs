        public T GetResult<T>(int id, string typeName) {
            AccrualTrackingEntities db = new AccrualTrackingEntities();
            var result = db.CreateQuery<T>(String.Format("[{0}]", typeName));
            var param = Expression.Parameter(typeof(T));
            var lambda = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(param, "TypeID"),
                    Expression.Constant(id)),
                param);
            return result.Single(lambda);
        }
