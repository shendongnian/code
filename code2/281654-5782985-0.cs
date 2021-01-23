    namespace MyNamespace {
        public static class MyClass {
        
            public static readonly DependencyProperty MyPropertyProperty = DependencyProperty.RegisterAttached("MyProperty",
                typeof(string), typeof(MyClass), new FrameworkPropertyMetadata(null));
                
            public static string GetMyProperty(UIElement element) {
                if (element == null)
                    throw new ArgumentNullException("element");
                return (string)element.GetValue(MyPropertyProperty);
            }
            public static void SetMyProperty(UIElement element, string value) {
                if (element == null)
                    throw new ArgumentNullException("element");
                element.SetValue(MyPropertyProperty, value);
            }
        }
    }
