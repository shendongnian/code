    Type model = Type.GetType($"{Assembly.GetExecutingAssembly().GetName().Name}.Models.{className}");
    DataTable tbl = dataSet.Tables[0];
    MethodInfo method = typeWhereConvertDataTableIsDefined.GetMethod("ConvertDataTable");
    MethodInfo generic = method.MakeGenericMethod(model);
    var result = generic.Invoke(null, null);
