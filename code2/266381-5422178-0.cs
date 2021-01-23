     public static class InputContext
        {
            private enum SHIC_FEATURE : uint
            {
                RESTOREDEFAULT = 0,
                AUTOCORRECT = 1,
                AUTOSUGGEST = 2,
                HAVETRAILER = 3,
                CLASS = 4
            }
    
            [DllImport("aygshell.dll")]
            private static extern int SHSetInputContext(IntPtr hwnd, SHIC_FEATURE dwFeature, ref bool lpValue);
    
            public static void SetAutoSuggestion(IntPtr handle, bool enable)
            {
                SHSetInputContext(handle, SHIC_FEATURE.AUTOSUGGEST, ref enable);
                SHSetInputContext(handle, SHIC_FEATURE.AUTOCORRECT, ref enable);
            }
        }
