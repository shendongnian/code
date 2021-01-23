    public static readonly DependencyProperty CurrentColorProperty=
            DependencyProperty.Register("CurrentColor",
                typeof(SolidColorBrush), typeof(ColorPicker),
                new PropertyMetadata(new SolidColorBrush(Colors.Gray)));
        public SolidColorBrush CurrentColor
        {
            get
            {
                return (SolidColorBrush)GetValue(CurrentColorProperty);
            }
            private set
            {
                SetValue(CurrentColorProperty, value);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Shape r = (b.Content) as Shape;
            SolidColorBrush sb = new SolidColorBrush(Colors.Yellow);
            sb = (SolidColorBrush)r.Fill;
            this.CurrentColor = sb;
        }
