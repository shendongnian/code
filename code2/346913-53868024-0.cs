    public class DragMoveBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }
        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is Window window)
            {
                // In maximum window state case, window will return normal state and
                // continue moving follow cursor
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                    // 3 or any where you want to set window location after
                    // return from maximum state
                    Application.Current.MainWindow.Top = 3;
                }
                window.DragMove();
            }
        }
    }
