    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class ObjectExtensions
    {
        public static void ThrowOnNullProperty(this object obj)
        {
            ThrowOnNullProperty(obj, new HashSet<object>());
        }
        private static void ThrowOnNullProperty(object obj, HashSet<object> visitedObjects)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (obj.GetType().IsPrimitive || obj.GetType() == typeof(string))
                return;
            if (visitedObjects.Contains(obj))
                return;
            visitedObjects.Add(obj);
            var nullPropertyNames = obj.GetType().GetProperties()
               .Where(p => p.GetValue(obj) == null)
               .Select(p => p.Name);
            if (nullPropertyNames.Any())
                throw new ArgumentException(
                    $"Null properties: {string.Join(",", nullPropertyNames)}");
            var notNullPropertyValues = obj.GetType().GetProperties()
                .Select(p => p.GetValue(obj))
                .Where(v => v != null);
            foreach (var item in notNullPropertyValues)
                ThrowOnNullProperty(item, visitedObjects);
        }
    }
