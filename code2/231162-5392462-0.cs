    // this sucks, but since we don't track true SQL types through the query, and ADO throws exception if you
    // call the wrong accessor, the best we can do is call GetValue and Convert.ChangeType
    Expression value = Expression.Convert(
        Expression.Call(typeof (Convert), "ChangeType", null,
                        Expression.Call(reader, "GetValue", null, Expression.Constant(iOrdinal)),
                        Expression.Constant(TypeHelper.GetNonNullableType(column.Type), typeof(Type))
            ),
        column.Type
        );
