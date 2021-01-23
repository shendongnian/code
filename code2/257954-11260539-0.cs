    public static void ClearCache(this OneFmDataContext context)
        {
            context.GetType().InvokeMember(
                "ClearCache",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.InvokeMethod,
                null, context, null);
        }
