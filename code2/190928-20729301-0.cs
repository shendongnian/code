    public static Expression<Func<TPoco, bool>> GetEqualsPredicate<TPoco>(string propertyName,
                                                                              object value)
                                                                              Type fieldType )
        {     
            var parameterExp = Expression.Parameter(typeof(TPoco), @"t");   //(tpoco t)
            var propertyExp = Expression.Property(parameterExp, propertyName);// (tpoco t) => t.Propertyname
          
            var someValue = fieldType.IsEnum // get and eXpressionConstant.  Careful Enums must be reduced
                         ? Expression.Constant(Enum.ToObject(fieldType, value)) // Marc Gravell fix
                         : Expression.Constant(value, fieldType);
            
            var equalsExp = Expression.Equal(propertyExp,  someValue); // yes this could 1 unreadble state if embedding someValue determination
            return Expression.Lambda<Func<TPoco, bool>>(equalsExp, parameterExp); 
        }
