    public static class RoleExtension
    {
        public static bool Match(this Role role, object obj )
        {
            var property = obj.GetType().GetProperty(role.objectProperty);
            if (property.PropertyType == typeof(int))
            {
                return ApplyIntOperation(role, (int)property.GetValue(obj, null));
            }
            if (property.PropertyType == typeof(string))
            {
                return ApplyStringOperation(role, (string)property.GetValue(obj, null));
            }
            if (property.PropertyType.GetInterface("IEnumerable<string>",false) != null)
            {
                return ApplyListOperation(role, (IEnumerable<string>)property.GetValue(obj, null));
            }
            throw new InvalidOperationException("Unknown PropertyType");
        }
        private static bool ApplyIntOperation(Role role, int value)
        {
            var targetValue = Convert.ToInt32(role.TargetValue);
            switch (role.ComparisonOperator)
            {
                case "greater_than":
                    return value > targetValue;
                case "equal":
                    return value == targetValue;
                //...
                default:
                    throw new InvalidOperationException("Unknown ComparisonOperator");
            }
        }
        private static bool ApplyStringOperation(Role role, string value)
        {
            //...
            throw new InvalidOperationException("Unknown ComparisonOperator");
        }
        private static bool ApplyListOperation(Role role, IEnumerable<string> value)
        {
            var targetValues = role.TargetValue.Split(' ');
            switch (role.ComparisonOperator)
            {
                case "hasAtLeastOne":
                    return value.Any(v => targetValues.Contains(v));
                    //...
            }
            throw new InvalidOperationException("Unknown ComparisonOperator");
        }
    }
