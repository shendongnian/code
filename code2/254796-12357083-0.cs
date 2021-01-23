    /// <summary>
    /// Change the "default" of all string properties for a given entity to varchar instead of nvarchar.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="entityType"></param>
    protected void SetAllStringPropertiesAsNonUnicode(
        DbModelBuilder modelBuilder,
        Type entityType)
    {
        var stringProperties = entityType.GetProperties().Where(
            c => c.PropertyType == typeof(string)
               && c.PropertyType.IsPublic 
               && c.CanWrite
               && !Attribute.IsDefined(c, typeof(NotMappedAttribute)));
        foreach (PropertyInfo propertyInfo in stringProperties)
        {
            dynamic propertyExpression = GetPropertyExpression(propertyInfo);
            MethodInfo entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
            MethodInfo genericEntityMethod = entityMethod.MakeGenericMethod(entityType);
            object entityTypeConfiguration = genericEntityMethod.Invoke(modelBuilder, null);
            MethodInfo propertyMethod = entityTypeConfiguration.GetType().GetMethod(
                "Property", new Type[] { propertyExpression.GetType() });
            StringPropertyConfiguration property = (StringPropertyConfiguration)propertyMethod.Invoke(
                entityTypeConfiguration, new object[] { propertyExpression });
            property.IsUnicode(false);
        }
    }
    private static LambdaExpression GetPropertyExpression(PropertyInfo propertyInfo)
    {
        var parameter = Expression.Parameter(propertyInfo.ReflectedType);
        return Expression.Lambda(Expression.Property(parameter, propertyInfo), parameter);
    }
    /// <summary>
    /// Return an enumerable of all DbSet entity types in "this" context.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    private IEnumerable<Type> GetEntityTypes()
    {
        return this
            .GetType().GetProperties()
            .Where(a => a.CanWrite && a.PropertyType.IsGenericType && a.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .Select(a => a.PropertyType.GetGenericArguments().Single());
    }
