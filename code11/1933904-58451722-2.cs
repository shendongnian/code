    public static class MyExtensions
    {
        private static readonly object initialBindingTarget = new object();
        public static object GetSomething(DependencyObject obj) => obj.GetValue(SomethingProperty);
        public static void SetSomething(DependencyObject obj, object value) => obj.SetValue(SomethingProperty, value);
        public static readonly DependencyProperty SomethingProperty =
            DependencyProperty.RegisterAttached(
                "Something",
                typeof(object),
                typeof(MyExtensions),
                new FrameworkPropertyMetadata(
                    initialBindingTarget,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) =>
            {
                // Trick to see if this is the first time we're set
                if (e.OldValue == initialBindingTarget)
                {
                    // Do your first-time initialisation here
                }
            }));
    }
