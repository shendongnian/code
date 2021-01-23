    public static Func<TArg0, TArg1, TResult> Compile<TArg0, TArg1, TResult>(Expression<Func<TArg0, TArg1, TResult>> query) where TArg0 : DataContext
    {
      if (query == null)
        System.Data.Linq.Error.ArgumentNull("query");
      if (CompiledQuery.UseExpressionCompile((LambdaExpression) query))
        return query.Compile();
      else
        return new Func<TArg0, TArg1, TResult>(new CompiledQuery((LambdaExpression) query).Invoke<TArg0, TArg1, TResult>);
    }
