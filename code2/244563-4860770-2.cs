    void Foo<T>(string fieldName, T value) {
       var param = Expression.Parameter(typeof(YourType), "x");
       var body = Expression.Equal(
                      Expression.PropertyOrField(param, fieldName),
                      Expression.Constant(value, typeof(T))
                   );
       var lambda = Expression.Lambda<Func<YourType, bool>>(body, param);
    }
