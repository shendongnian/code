    private static void UpdateSensor(Sensors jsonUpdate, Expression<Func<Sensors, JsonSensor<double>>> propertySelector)
    {
        if (propertySelector.Body is MemberExpression expression)
        {
            var compiledExpression = propertySelector.Compile();
            // Signature was changed and jsonUpdate is not compiled into lambda; we need to pass reference
            var jsonSensor = compiledExpression.Invoke(jsonUpdate);
            var name = expression.Member.Name;
            var cabinetSensor = SensorMap[name];
            cabinetSensor.Value = jsonSensor.Value.ToString($"F{cabinetSensor.Precision}");
        }
    }
    public IEnumerable<Sensor> Test(Sensors jsonUpdate)
    {
        foreach (var property in Properties)
        {
            var parameterExpression = Expression.Parameter(jsonUpdate.GetType());
            // You don't need call or GetMethod, you need to access Property
            var propertyCall = Expression.Property(parameterExpression, property);
            // Cast is redundant, and if you add it UpdateSensor will do nothing
            // UnaryExpression castToObject = Expression.Convert(propertyCall, typeof(JsonSensor<double>));
            var lambda = Expression.Lambda<Func<Sensors, JsonSensor<double>>>(propertyCall, parameterExpression);
            UpdateSensor(jsonUpdate, lambda);
        }
        // not relevant
        return null;
    }
