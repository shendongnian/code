     public static Expression<Func<T, bool>> BuildWhereExpression<T>(string nameValueQuery ) where  T : class 
            {
                Expression<Func<T, bool>> predicate = null;
                PropertyInfo prop = null;
                var fieldName = nameValueQuery.Split("=")[0];
                var fieldValue = nameValueQuery.Split("=")[1];
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    if (property.Name.ToLower() == fieldName.ToLower())
                    {
                        prop = property;
                    }
                } 
                if (prop != null)
                {
                    var isNullable = prop.PropertyType.IsNullableType();
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var member = Expression.Property(parameter, fieldName); 
                    if (isNullable)
                    {
                        var filter1 =
                            Expression.Constant(
                                Convert.ChangeType(fieldValue, member.Type.GetGenericArguments()[0]));
                        Expression typeFilter = Expression.Convert(filter1, member.Type);
                        var body = Expression.Equal(member, typeFilter);  
                        predicate = Expression.Lambda<Func<T, bool>>(body, parameter);  
                    }
                    else
                    {
                        if (prop.PropertyType == typeof(string) && likeOerator.ToLower() == "like")
                        {
                            var parameterExp = Expression.Parameter(typeof(T), "type");
                            var propertyExp = Expression.Property(parameterExp, prop);
                            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                            var someValue = Expression.Constant(fieldValue, typeof(string));
                            var containsMethodExp = Expression.Call(propertyExp, method, someValue);
                            predicate = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
                        }
                        else
                        {
                            var constant = Expression.Constant(Convert.ChangeType(fieldValue, prop.PropertyType));
                            var body = Expression.Equal(member, constant);  
                            predicate = Expression.Lambda<Func<T, bool>>(body, parameter); `enter code here`
                        }
                    }
                }
                return predicate;
            }
    
     
