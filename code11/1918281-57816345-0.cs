    public static class WindowManager
    {
        public static T GetWindow<T>()
        {
            var t = Application.Current.Windows.OfType<T>().FirstOrDefault();
            if (t == null)
            {
                t = (T)Activator.CreateInstance(typeof(T));
            }
            return t;
        }
        public static T CreateOrFocusWindow<T>()
        {
            var t = GetWindow<T>();
            if (t is Window)
            {
                var window = t as Window;
                if (window.Visibility != Visibility.Visible)
                    window.Show();
                if (window.WindowState == WindowState.Minimized)
                    window.WindowState = WindowState.Normal;
                window.Focus();
            }
            return t;
        }
    }
 
