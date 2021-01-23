    foreach ( AssemblyName assemName in assemComponents )
    {
        foreach ( var type in Assembly.Load( assem ).GetTypes() )
        {
            // look for classes that derive from SettingsBase named "Settings"
            if ( type.Name == "Settings" && typeof( SettingsBase ).IsAssignableFrom( type ) )
            {
                // get the value of the static Default property
                var defaults = (SettingsBase)type.GetProperty( "Default" ).GetValue( null, null );
                // walk the property list and get the value from the Default instance
                foreach ( SettingsProperty prop in defaults.Properties )
                {
                    Debug.WriteLine( string.Format( "{0}: {1}", prop.Name, defaults[ prop.Name ] ) );
                }
            }
        }
    }
