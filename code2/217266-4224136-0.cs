     'generate a delegate that can access the protected control property "ViewState" 
     '(by using LINQ expressions, we can avoid the performance hit of reflection)
      Dim cntrlParam As ParameterExpression = Expression.Parameter(GetType(Control), "cntrl")
      Dim vsPropertyAcessor As MemberExpression = Expression.Property(cntrlParam, "ViewState")
      _ViewStateAccessor = Expression.Lambda(vsPropertyAcessor, cntrlParam).Compile()
