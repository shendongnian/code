    var baseParameter = Expression.Parameter(typeof(T), "base");
            var resultParameter = Expression.Parameter(typeof(D), "result");
            var bindings = typeof(D).GetProperties().Select(x =>
                                                    {
                                                        var attr = x.GetCustomAttribute<AtpPropertyInfoAttribute>();
                                                        var entityProperties = attr != null && !string.IsNullOrEmpty(attr.EntityProperty) ? attr.EntityProperty.Split('.') : new string[] { x.Name };
                                                        Expression entityProperty = Expression.Property(baseParameter, entityProperties[0]);
                                                        for (int i = 1; i < entityProperties.Length; i++)
                                                        {
                                                            entityProperty = Expression.Property(entityProperty, entityProperties[i]);
                                                        }
                                                        return Expression.Bind(Expression.Property(resultParameter, x.Name).Member, entityProperty);
                                                    });
            return Expression.Lambda<Func<T, D>>(Expression.MemberInit(Expression.New(typeof(D)), bindings), baseParameter);
