    // Check all properties for a dependency property attribute.
    const BindingFlags ALL_PROPERTIES = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    var matchingProperties = new Dictionary<PropertyInfo, DependencyPropertyAttribute>();
    foreach ( PropertyInfo property in m_ownerType.GetProperties( ALL_PROPERTIES ) )
    {
        object[] attribute = property.GetCustomAttributes( typeof( DependencyPropertyAttribute ), false );
        if ( attribute != null && attribute.Length == 1 )
        {
            // A correct attribute was found.
            DependencyPropertyAttribute dependency = (DependencyPropertyAttribute)attribute[ 0 ];
            // Check whether the ID corresponds to the ID required for this factory.
            if (dependency.GetId() is T)
            {
                matchingProperties.Add(property, dependency);
            }
        }
    }
