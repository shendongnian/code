        private IEnumerable<Type> GetControllers()
        {
            return from t in typeof(MyType).Assembly.GetTypes()
                   where t.IsAbstract == false
                   where typeof(Controller).IsAssignableFrom(t)
                   where t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                   select t;
        }
