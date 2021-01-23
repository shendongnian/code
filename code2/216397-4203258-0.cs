    public static class PermissionExtensions
    {
        public static object SelectProperty(this Permission obj, string variable)
        {
            return obj.GetType().GetProperty(variable).GetValue(obj, null);
        }
    }
