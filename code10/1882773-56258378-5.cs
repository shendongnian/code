    public static class MemberInfoExtension
    {
        private static readonly Dictionary<MemberInfo, BindingFlags> cache =
            new Dictionary<MemberInfo, BindingFlags>();
        private static readonly BindingFlags flags =
            BindingFlags.Instance | BindingFlags.NonPublic;
        public static BindingFlags GetFlags(this MemberInfo memberInfo)
        {
            if (cache.TryGetValue(memberInfo, out var bindingFlags))
                return bindingFlags;
            return cache[memberInfo] =
                (BindingFlags)memberInfo.GetType()
                                        .GetProperty("BindingFlags", flags)
                                        .GetValue(memberInfo);
        }
    }
