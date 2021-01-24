    public class Filterclass<T> where T : class {
        public static string ColumnName;
        public static SampleFilterModel filter = new SampleFilterModel();
        public static IEnumerable<T> input;
        static readonly MethodInfo startsWith = typeof(string).GetMethod("StartsWith");
        public Func<SampleFilterModel, IEnumerable<T>> filterData = (filterModel) => {
            var type = typeof(T);
            var propertyInfo = type.GetProperty(ColumnName);
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
                .Skip((filterModel.Page - 1) * filter.Limit)
                .Take(filterModel.Limit);
        };
    }
