    case WhereOperation.Contains:
        var toLower = Expression.Call(memberAccessToString,
                                      typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
        condition = Expression.Call(toLower,
                                    typeof(string).GetMethod("Contains"),
                                    Expression.Constant(value.ToString().ToLower()));
        lambda = Expression.Lambda(condition, parameter);
        break;
