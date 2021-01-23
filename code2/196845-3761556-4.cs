    class InputMapper<T>
    {
        public void Map<TProperty>(string input,
                                   Expression<Func<T, TProperty>> propertyExpression,
                                   string errorMessage);
    }
