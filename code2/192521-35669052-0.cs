        public static IList OfTypeToList(this IEnumerable source, Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return
                (IList) Activator.CreateInstance(
                    typeof(List<>)
                       .MakeGenericType(type),
                    typeof(System.Linq.Enumerable)
                       .GetMethod(nameof(System.Linq.Enumerable.OfType),
                                  BindingFlags.Static | BindingFlags.Public)
                       .MakeGenericMethod(type)
                       .Invoke(null, new object[] { source }));
        }
