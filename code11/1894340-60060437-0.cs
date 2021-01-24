    public static readonly DependencyProperty MytextDependencyProperty =
                DependencyProperty.Register("MyText", typeof(string), typeof(TestClass), new PropertyMetadata(null, PropertyChangedCallbackAsync));
        private static async void PropertyChangedCallbackAsync(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            await someMethod();
        }
