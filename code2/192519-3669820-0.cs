    MethodInfo method = typeof(Queryable).GetMethod("OfType");
    MethodInfo generic = method.MakeGenericMethod(new Type[]{ type });
    // Use .NET 4 covariance
    var result = (IEnumerable<object>) generic.Invoke
          (null, new object[] { context.Resources });
    object[] array = result.ToArray();
