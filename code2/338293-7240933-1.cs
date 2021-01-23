    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Windows.Media;
    namespace CustomWindow
    {
        public partial class BaseResource
        {
            private const uint WM_SYSCOMMAND = 0x112;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr 
                SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
            private void CloseButton_Click(object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                Window.GetWindow((DependencyObject) sender).Close();
            }
            private void MinimizeButton_Click(object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                Window.GetWindow((DependencyObject) sender).WindowState = WindowState.Minimized;
            }
            private void MaximizeButton_Click(object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                var window = Window.GetWindow((DependencyObject) sender);
                window.WindowState = 
                  (window.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
            }
            private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
            {
                e.Handled = true;
                Window.GetWindow((DependencyObject) sender).DragMove();
            }
            private void Border_MouseDown(object sender, MouseButtonEventArgs e)
            {
                e.Handled = true;
                var direction = (Direction)Enum.Parse(typeof(Direction), ((FrameworkElement)sender).Tag.ToString());
                ResizeWindow(PresentationSource.FromVisual((Visual)sender) as HwndSource, direction);
            }
            private void ResizeWindow(HwndSource hwndSource, Direction direction)
            {
                SendMessage(hwndSource.Handle, WM_SYSCOMMAND, (int)(61440 + direction), 0);
            }
            private enum Direction
            {
                Left = 1,
                Right = 2,
                Top = 3,
                TopLeft = 4,
                TopRight = 5,
                Bottom = 6,
                BottomLeft = 7,
                BottomRight = 8,
            }
        }
    }
