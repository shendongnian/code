    public static Expression<Action> UsingBoilerPlate(
                     Expression disposeExpression,
                     Expression bodyExpression,
                     ParameterExpression localVariable,
                     bool unbound) { ... }
    public static Expression<Action> UsingBoilerPlate(
                     Expression disposeExpression,
                     Expression bodyExpression,
                     ParameterExpression localVariable)
    {  return UsingBoilerPlate(disposeExpression, bodyExpression, localVariable, true); }
    public static Expression<Action> UsingBoilerPlate(
                     Expression disposeExpression,
                     Expression bodyExpression)
    {  return UsingBoilerPlate(disposeExpression, bodyExpression, null); }
