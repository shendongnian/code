        private static readonly HashSet<DataGridRow> _rows = new HashSet<DataGridRow>();
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(object),
            typeof(Animator), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));
        public static object GetValue(DataGridRow d) => d.GetValue(ValueProperty);
        public static void SetValue(DataGridRow d, object value) => d.SetValue(ValueProperty, value);
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRow row = (DataGridRow)d;
            if (!_rows.Contains(row))
            {
                _rows.Add(row);
                row.Unloaded += Row_Unloaded;
            }
            else
            {
                ColorAnimation animation = new ColorAnimation();
                animation.From = Colors.Gray;
                animation.To = Colors.White;
                animation.Duration = new Duration(TimeSpan.FromSeconds(1));
                Storyboard.SetTarget(animation, row);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Color"));
                Storyboard sb = new Storyboard();
                sb.Children.Add(animation);
                sb.Begin();
            }
        }
        private static void Row_Unloaded(object sender, RoutedEventArgs e)
        {
            DataGridRow row = (DataGridRow)sender;
            _rows.Remove(row);
            row.Unloaded -= Row_Unloaded;
        }
    }
