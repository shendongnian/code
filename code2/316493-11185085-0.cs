    using System.Collections.Generic;
    using System.Reflection;
    namespace WpfApplication4
    {
        public static class EFExtensions
        {
            /// <summary>
            /// Rejects changes made by user
            /// </summary>
            /// <param name="param">Object implementing IObjectWithChangeTracker interface</param>
            public static void RejectChanges(this IObjectWithChangeTracker param)
            {
                OriginalValuesDictionary ovd = param.ChangeTracker.OriginalValues;
                PropertyInfo[] propertyInfos = (param.GetType()).GetProperties();
                foreach (KeyValuePair<string, object> pair in ovd)
                {
                    foreach (PropertyInfo property in propertyInfos)
                    {
                        if (property.Name == pair.Key && property.CanWrite)
                        {
                            property.SetValue(param, pair.Value, null);
                        }
                    }
                }
            }
        }
    }
