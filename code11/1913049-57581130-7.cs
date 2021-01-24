    public static class Filterclass {
        static readonly MethodInfo startsWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string), typeof(System.StringComparison) });
        public static IEnumerable<T> FilterData<T>(this IEnumerable<T> input, FilterModel filterModel) where T : class {
            var type = typeof(T);
            var propertyInfo = type.GetProperty(filterModel.ColumnName);
            //T p =>
            var parameter = Expression.Parameter(type, "p");
            //T p => p.ColumnName
            var name = Expression.Property(parameter, propertyInfo);
            // filterModel.Term ?? String.Empty
            var term = Expression.Constant(filterModel.Term ?? String.Empty);
            //StringComparison.InvariantCultureIgnoreCase
            var comparison = Expression.Constant(StringComparison.InvariantCultureIgnoreCase);
            //T p => p.ColumnName.StartsWith(filterModel.Term ?? String.Empty, StringComparison.InvariantCultureIgnoreCase)
            var methodCall = Expression.Call(name, startsWith, term, comparison);
            var lambda = Expression.Lambda<Func<T, bool>>(methodCall, parameter);
            return input.Where(lambda.Compile())
            .Skip((filterModel.Page - 1) * filterModel.Limit)
            .Take(filterModel.Limit);
        }
    }
