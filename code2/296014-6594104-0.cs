        foreach (Control uie in FindInLogicalTreeDown(this, typeof(TextBox))) AssignEvents(uie);
        private static IEnumerable<DependencyObject> FindInLogicalTreeDown(DependencyObject obj, Type type)
        {
            if (obj != null)
            {
                if (obj.GetType() == type) { yield return obj; }
                foreach (object child in LogicalTreeHelper.GetChildren(obj)) 
                    if (typeof(DependencyObject).IsAssignableFrom(child.GetType()))
                        foreach (var nobj in FindInLogicalTreeDown((DependencyObject)child, type)) yield return nobj;
            }
            yield break;
        }
        void AssignEvents(Control element)
        {
            element.GotMouseCapture += new MouseEventHandler(Component_GotFocus);
        }
        public Control LastFocus { get; set; }
        public void Component_GotFocus(object sender, RoutedEventArgs e)
        {
            LastFocus = (Control)sender;
            if (LastFocus.GetType() == typeof(TextBox)) { KeyboardVisible = true; }
        }
