    [Flags]
    public enum PropertyRecursionOverflowProtectionType
    {
        SkipSameReference,
        SkipSameType
    }
    public class PropertyRecursionBot
    {
        public object ParentObject { get; set; }
        public object CurrentObject { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public Type ParentType { get; set; }
        public int Level { get; set; }
    }
    public static IEnumerable<PropertyRecursionBot> GetAllProperties(object entity,
        PropertyRecursionOverflowProtectionType overflowProtectionType = PropertyRecursionOverflowProtectionType.SkipSameReference)
    {
        var type = entity.GetType();
        var bot = new PropertyRecursionBot { CurrentObject = entity };
        IEnumerable<PropertyRecursionBot> GetAllProperties(PropertyRecursionBot innerBot, PropertyInfo[] properties)
        {
            var currentParentObject = innerBot.ParentObject;
            var currentObject = innerBot.CurrentObject;
            foreach (var pi in properties)
            {
                innerBot.PropertyInfo = pi;
                var obj = pi.GetValue(currentObject);
                innerBot.CurrentObject = obj;
                //Return the property and value only if it's a value type or string
                if (pi.PropertyType == typeof(string) || !pi.PropertyType.IsClass)
                {
                    yield return innerBot;
                    continue;
                }
                //This overflow protection check will prevent stack overflow if your object has bidirectional navigation
                else if (innerBot.CurrentObject == null ||
                    (overflowProtectionType.HasFlag(PropertyRecursionOverflowProtectionType.SkipSameReference) && innerBot.CurrentObject == currentParentObject) ||
                    (overflowProtectionType.HasFlag(PropertyRecursionOverflowProtectionType.SkipSameType) && innerBot.CurrentObject.GetType() == currentParentObject?.GetType()))
                {
                    continue;
                }
                innerBot.Level++;
                innerBot.ParentObject = currentObject;
                foreach (var innerPi in GetAllProperties(innerBot, pi.PropertyType.GetProperties()))
                {
                    yield return innerPi;
                }
                innerBot.Level--;
                innerBot.ParentObject = currentParentObject;
                innerBot.CurrentObject = obj;
            }
        }
        foreach (var pi in GetAllProperties(bot, type.GetProperties()))
        {
            yield return pi;
        }
    }
