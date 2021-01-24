    var parameter = Expression.Parameter(entity.ClrType, "e");
    var body = Expression.NotEqual(
        Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(DateTime?) }, parameter, Expression.Constant("DeletedAt")),
        Expression.Constant(null));
    modelBuilder.Entity(entity.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
