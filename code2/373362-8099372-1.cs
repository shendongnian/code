     private void AllButtons_Click(object sender, System.Windows.RoutedEventArgs e) {
      var b = sender as Button;
      // in order to remain hit testable, hide the element 
      // by setting its Opacity property, not the Visibility property
      // also note that semi transparent objects can affect performance
      b.Opacity = b.Opacity >= 1.0 ? 0.0 : 1.0; 
      var locationPoint = b.TransformToVisual(LayoutRoot).Transform(new Point());
      PageTitle.Text = String.Format("{0},{1}",locationPoint.X, locationPoint.Y) ;
    }
 
