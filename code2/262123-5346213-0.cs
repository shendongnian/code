    internal abstract class AbstractMappingProvider<T> : IMappingProvider where T : class
    {
        public EntityTypeConfiguration<T> Map { get; private set; }
        public virtual void DefineModel(DbModelBuilder modelBuilder)
        {
            Map = modelBuilder.Entity<T>();
            Map.ToTable(typeof(T).Name);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.PropertyType.IsEnum);
            var parameterExpression = Expression.Parameter(typeof(T), "e");
            
            foreach (var propertyInfo in properties)
            {
                // Build up the expression
                var propertyExpression = Expression.Property(parameterExpression, propertyInfo);
                var funcType = typeof (Func<,>).MakeGenericType(typeof (T), propertyInfo.PropertyType);
                var ignoreExpression = Expression.Lambda(funcType, propertyExpression, new[] {parameterExpression});
                // Call the generic Ignore method on this class, passing in the expression
                var ignoreMethod = this.GetType().GetMethod("Ignore");
                var genericIgnoreMethod = ignoreMethod.MakeGenericMethod(propertyInfo.PropertyType);
                genericIgnoreMethod.Invoke(this, new object[]{ignoreExpression});
            }
        }
        public void Ignore<TPropertyType>(LambdaExpression lambdaExpression)
        {
            var expression = (Expression<Func<T, TPropertyType>>) lambdaExpression;
            Map.Ignore(expression);
        }
    }
