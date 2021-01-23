    public static class TypeNameExtensions
    {
        public static string GetFriendlyName(this Type type)
        {
            var friendlyName = type.Name;
            if (!type.IsGenericType) return friendlyName;
            var iBacktick = friendlyName.IndexOf('`');
            if (iBacktick > 0) friendlyName = friendlyName.Remove(iBacktick);
            var genericParameters = type.GetGenericArguments().Select(x => x.GetFriendlyName());
            friendlyName += "<" + string.Join(", ", genericParameters) + ">";
            return friendlyName;
        }
    }
