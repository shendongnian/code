    /// <summary>
    /// Creates predicate expression like 
    /// <code>(T t) => t.SomeProperty.Contains("Constant")</code> 
    /// where "SomeProperty" name is defined by <paramref name="stringConstant"/> parameter, and "Constant" is the <paramref name="stringConstant"/>.
    /// If property has non-string type, it is converted to string with <see cref="object.ToString()"/> method.
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    /// <param name="propertyName">Property name</param>
    /// <param name="stringConstant">String constant to construnt the <see cref="string.Contains(string)"/> expression.</param>
    /// <param name="caseInsensitive">Case insenstive Contains Predicate?</param>
    /// <returns>Predicate instance</returns>
    public static Expression<Func<T, bool>> BuildStringContainsPredicate<T>(string propertyName, string stringConstant, bool caseInsensitive)
    {
        var type = typeof(T);
        var parameterExp = Expression.Parameter(type, "e");
        var propertyExp = BuildPropertyExpression(parameterExp, propertyName);
        Expression exp = propertyExp;
        // if the property value type is not string, it needs to be casted at first
        if (propertyExp.Type != typeof(string))
        {
            // If we have an Enum, the underlying Entity Framework Provider can not translate the Enum to SQL.
            // Therefore we converting it first to the underlying primitive type (byte, int16, int32, int64 etc)
            //Todo: Sideeffects beobachten
            //Todo: Evtl möglichkeit finden Display Attribute zu implementieren um eine String Suche zu ermöglichen?
            //Todo: Notwendigkeit in NET Core 2.1 überprüfen
            if (propertyExp.Type.IsEnum)
            {
                exp = Expression.Convert(exp, Enum.GetUnderlyingType(propertyExp.Type));
            }
            exp = Expression.Call(exp, ObjectToString);
        }
        // call ToLower if case insensitive search
        if (caseInsensitive)
        {
            exp = Expression.Call(exp, StringToLower);
            stringConstant = stringConstant.ToLower();
        }
        var someValue = Expression.Constant(stringConstant, typeof(string));
        var containsMethodExp = Expression.Call(exp, StringContains, someValue);
        return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
    }
