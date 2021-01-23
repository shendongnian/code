    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Collections.Concurrent;
    namespace NetSteps.Common.Reflection
    {
        public static class Reflection
        {
            private static ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>> reflectionPropertyCache = new ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>>();
            public static List<PropertyInfo> FindClassProperties(Type objectType)
            {
                if (reflectionPropertyCache.ContainsKey(objectType))
                    return reflectionPropertyCache[objectType].Values.ToList();
                var result = objectType.GetProperties().ToDictionary(p => p.Name, p => p);
                reflectionPropertyCache.TryAdd(objectType, result);
                return result.Values.ToList();
            }
        }
    }
