        public static class DateKindHelper
        {
            /// <summary>
            /// Scans an object for all its properties, and sets the kind of DateTime and DateTime? ones to UTC.
            /// </summary>
            /// <param name="target">Any object, preferably POCO ones.</param>
            public static void SetAllDateTimeValuesAsUtc(object target)
            {
                if (target == null) return;
    
                // TODO: We could add a propertyInfo list cache in a static dictionary for each type, so it's faster.
    
                //Extract all DateTime properties of the object type
                var properties = target.GetType().GetProperties()
                    .Where(property => property.PropertyType == typeof(DateTime) ||
                                       property.PropertyType == typeof(DateTime?)).ToList();
                //Set all DaetTimeKinds to Utc
                properties.ForEach(property => SpecifyUtcKind(property, target));
            }
    
            private static void SpecifyUtcKind(PropertyInfo property, object value)
            {
                // If the property doesn't have a setter, we don nothing!
                if (property.SetMethod == null) return;
                
                //Get the datetime value
                var datetime = property.GetValue(value, null);
    
                //set DateTimeKind to Utc
                if (property.PropertyType == typeof(DateTime))
                {
                    datetime = DateTime.SpecifyKind((DateTime)datetime, DateTimeKind.Utc);
                }
                else if (property.PropertyType == typeof(DateTime?))
                {
                    var nullable = (DateTime?)datetime;
                    if (!nullable.HasValue) return;
                    datetime = (DateTime?)DateTime.SpecifyKind(nullable.Value, DateTimeKind.Utc);
                }
                else
                {
                    return;
                }
    
                //And set the Utc DateTime value
                property.SetValue(value, datetime, null);
            }
        }
