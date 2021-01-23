      public partial class MainWindow : Window {
        public MainWindow() {
          InitializeComponent();
          }
    
        private void OnPoint1Down( object sender, MouseButtonEventArgs e ) {
          Mouse.Capture( thumb1 );
          }
    
        private void OnPoint1Up( object sender, MouseButtonEventArgs e ) {
          Mouse.Capture( null );
          }
    
        private void OnPoint1Move( object sender, MouseEventArgs e ) {
    
          if ( e.LeftButton == MouseButtonState.Pressed ) {
    
            var point = e.GetPosition( myCanvas );
    
            myLine.X1 = point.X;
            myLine.Y1 = point.Y;
    
            Canvas.SetLeft( thumb1, point.X - thumb1.Width/2 );
            Canvas.SetTop( thumb1, point.Y - thumb1.Height/2 );
            }
          }
        }
