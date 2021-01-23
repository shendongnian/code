    public static class FormUtils
    {
        private static Icon _defaultFormIcon;
        public static Icon DefaultFormIcon
        {
            get
            {
                if (_defaultFormIcon == null)
                    _defaultFormIcon = (Icon)typeof(Form).
                        GetProperty("DefaultIcon", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).
                        GetValue(null, null);
                return _defaultFormIcon;
            }
        }
    }
    public static class FormExtensions
    {
        internal static void GetIconIfDefault(this Form dest, Form source)
        {
            if (dest.Icon == FormUtils.DefaultFormIcon)
                dest.Icon = source.Icon;
        }
    }
