            [SuppressUnmanagedCodeSecurity]
            internal static class SafeNativeMethods
            {
                [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
                public static extern int StrCmpLogicalW(string p1, string p2);
            }
    
            public sealed class StringComparer : IComparer<string>
            {
                public int Compare(string a, string b)
                {
                    return SafeNativeMethods.StrCmpLogicalW(a, b);
                }
            }
