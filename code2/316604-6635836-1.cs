    ParameterExpression paramExp = Expression.Parameter(t, "p");
            // the parameter: p
    
    MemberExpression otherEntityExp = Expression.MakeMemberAccess(paramExp,
                                                                     t.GetMember("anotherentity").FirstOrDefault());     
    
    MemberExpression memberExp = Expression.MakeMemberAccess(otherEntityExp,
                                                                     t.GetMember(propertyName).FirstOrDefault());
