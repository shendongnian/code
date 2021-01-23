    var columnExpr = Expression.MakeMemberAccess(entityParam, fieldPropertyInfo); // {e.fieldName}
    if (T.GetType().Equals(typeof(object)))
    {
        columnExpr = Expression.Convert(columnExpr, typeof(object));
    }
