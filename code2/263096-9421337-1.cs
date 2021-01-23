        private void mapControl_MapPan( object sender, MapDragEventArgs e )
        {
          if( isDragging )
          {
            e.Handled = true;
          }
        }
        private void pushpin_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
          isDragging = true;
        }
        private void pushpin_MouseLeftButtonUp( object sender, MouseButtonEventArgs e )
        {
          isDragging = false;
        }
