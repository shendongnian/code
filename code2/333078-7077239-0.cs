    var comparison = Expression.Lambda<Func<House, bool>>(
                    Expression.Equal(houseMainRoomTypeParam,
                    Expression.Constant("Kitchen", typeof(RoomType))));
    //now the type of comparison is Expression<Func<House, bool>>
    
    //the overload in Expression.cs
    public static Expression<TDelegate> Lambda<TDelegate>(Expression body, params ParameterExpression[] parameters);
