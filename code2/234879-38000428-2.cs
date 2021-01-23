    /// <summary> Sets the DateTime.Kind value on DateTime and DateTime? members retrieved by Entity Framework. Sets Kind to DateTimeKind.Utc by default. </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeKindAttribute : Attribute
    {
        /// <summary> The DateTime.Kind value to set into the returned value. </summary>
        public readonly DateTimeKind Kind;
        /// <summary> Specifies the DateTime.Kind value to set on the returned DateTime value. </summary>
        /// <param name="kind"> The DateTime.Kind value to set on the returned DateTime value. </param>
        public DateTimeKindAttribute(DateTimeKind kind)
        {
            Kind = kind;
        }
        /// <summary> Event handler to connect to the ObjectContext.ObjectMaterialized event. </summary>
        /// <param name="entity"> The entity (POCO class) being materialized. </param>
        /// <param name="defaultKind"> [Optional] The Kind property to set on all DateTime objects by default. </param>
        public static void Apply(object entity, DateTimeKind? defaultKind = null)
        {
            if (entity == null) return;
            // Get the PropertyInfos for all of the DateTime and DateTime? properties on the entity
            var properties = entity.GetType().GetProperties()
                .Where(x => x.PropertyType == typeof(DateTime) || x.PropertyType == typeof(DateTime?));
            // For each DateTime or DateTime? property on the entity...
            foreach (var propInfo in properties) {
                // Initialization
                var kind = defaultKind;
                // Get the kind value from the [DateTimekind] attribute if it's present
                var kindAttr = propInfo.GetCustomAttribute<DateTimeKindAttribute>();
                if (kindAttr != null) kind = kindAttr.Kind;
                // Set the Kind property
                if (kind != null) {
                    var dt = (propInfo.PropertyType == typeof(DateTime?))
                        ? (DateTime?)propInfo.GetValue(entity)
                        : (DateTime)propInfo.GetValue(entity);
                    
                    if (dt != null) propInfo.SetValue(entity, DateTime.SpecifyKind(dt.Value, kind.Value));
                }
            }
        }
    }
