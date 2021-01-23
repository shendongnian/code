    class InputMapper<T>
    {
        public void Map<TProperty>(string input,
                                   Action<TProperty> propertySetter,
                                   string errorMessage);
    }
