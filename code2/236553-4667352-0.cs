    public static string GetUniqueId<T, TProperty>(this IQueryable<T> source, int length, Expression<Func<T, TProperty>> idProperty)
        {
            bool isUnique = false;
            string uniqueId = String.Empty;
            while (!isUnique)
            {
                uniqueId = PasswordGenerator.GenerateNoSpecialCharacters(length);
                if (!String.IsNullOrEmpty(uniqueId))
                {
                    var expr = Expression.Lambda<Func<T, bool>>(
                        Expression.Call(idProperty.Body, typeof(string).GetMethod("Equals", new[] { typeof(string) }), Expression.Constant(uniqueId)), idProperty.Parameters);
                    isUnique = source.SingleOrDefault(expr) == null;
                }
            }
            return uniqueId;
        }
