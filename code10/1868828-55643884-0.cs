    var g = Expression.Parameter(typeof(IEnumerable<float?>), "g");
    // get the method definition using object as a placeholder parameter
    var countMethodOfObject = ((Func<IEnumerable<object>, int>)Enumerable.Count<object>).Method;
    // get the generic method definition
    var countMethod = countMethodOfObject.GetGenericMethodDefinition();
    // create generic method
    var countMaterialized = countMethod.MakeGenericMethod(new[] { typeof(float?) });
    // creare expression
    var countExpression = Expression.Call(countMaterialized, g);
    var expression = Expression.Lambda<Func<IEnumerable<float?>, int>>(countExpression, g);
    IEnumerable<float?> floats = Enumerable.Range(3, 5).Select(v => (float?)v);
    var count = expression.Compile().Invoke(floats);
