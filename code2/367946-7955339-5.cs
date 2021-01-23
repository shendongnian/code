    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace TestWpfApplication
    {
        public partial class MainWindow : System.Windows.Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var mousePosition = e.GetPosition(sender as UIElement);
                Canvas.SetLeft(selectionRectangle, mousePosition.X);
                Canvas.SetTop(selectionRectangle, mousePosition.Y);
                selectionRectangle.Visibility = System.Windows.Visibility.Visible;
            }
            private void Canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var mousePosition = e.GetPosition(sender as UIElement);
                    selectionRectangle.Width = mousePosition.X - Canvas.GetLeft(selectionRectangle);
                    selectionRectangle.Height = mousePosition.Y - Canvas.GetTop(selectionRectangle);
                }
            }
        }
    }
