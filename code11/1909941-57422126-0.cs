    public static class PermissionsExtensions {
        public static T CommandGroup<T>(this Permissions permissions, string commandGroup)
        {
             PropertyInfo commandGroupProperty = typeof(Permissions).GetProperty(commandGroup);
             return (T)(commandGroupProperty.GetValue( permissions));
        }
        public static bool CommandProperty<T>(this T commandGroup, string commandProperty) 
        {
            PropertyInfo commandPropertyProperty = typeof(T).GetProperty( commandProperty);
            return (bool)(commandPropertyProperty.GetValue( commandGroup));
        }
    }
