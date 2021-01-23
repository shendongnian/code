    Expression ParseMemberAccess(Type type, Expression instance)
    {
      // ...
            switch (FindMethod(type, id, instance == null, args, out mb))
            {
                case 0:
                    throw ParseError(errorPos, Res.NoApplicableMethod,
                        id, GetTypeName(type));
                case 1:
                    MethodInfo method = (MethodInfo)mb;
                    //if (!IsPredefinedType(method.DeclaringType)) // Comment out this line, and the next.
                        //throw ParseError(errorPos, Res.MethodsAreInaccessible, GetTypeName(method.DeclaringType));
                    if (method.ReturnType == typeof(void))
                        throw ParseError(errorPos, Res.MethodIsVoid,
                            id, GetTypeName(method.DeclaringType));
                    return Expression.Call(instance, (MethodInfo)method, args);
                default:
                    throw ParseError(errorPos, Res.AmbiguousMethodInvocation,
                        id, GetTypeName(type));
            }
      // ...
    }
