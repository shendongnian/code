    public class WindowHeaderButton : Window
    {
        private readonly Window _owner;
        public WindowHeaderButton(Window owner)
        {
            _owner = owner;
            _owner.Loaded += owner_Loaded;
            _owner.LocationChanged += owner_LocationChanged;
            _owner.StateChanged += owner_StateChanged;
            _owner.SizeChanged += owner_SizeChanged;
            _owner.Deactivated += _owner_Deactivated;
            _owner.Activated += _owner_Activated;
            Activated += WindowHeaderButton_Activated;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Background = new SolidColorBrush(Colors.Transparent);
            ShowInTaskbar = false;
        }
        void WindowHeaderButton_Activated(object sender, System.EventArgs e)
        {
            Opacity = 1;
        }
        void _owner_Activated(object sender, System.EventArgs e)
        {
            Opacity = 1;
        }
        void _owner_Deactivated(object sender, System.EventArgs e)
        {
            Opacity = 0.75;
        }
        private void owner_Loaded(object sender, RoutedEventArgs e)
        {
            Owner = _owner;
            Show();
            UpdatePosition();
        }
        private void owner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePosition();
        }
        private void owner_StateChanged(object sender, System.EventArgs e)
        {
            UpdatePosition();
        }
        private void owner_LocationChanged(object sender, System.EventArgs e)
        {
            UpdatePosition();
        }
        private void UpdatePosition()
        {
            Top = _owner.Top + 1;
            Left = _owner.Left + 8;
        }
    }
