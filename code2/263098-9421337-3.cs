            private void mapControl_MapPan( object sender, MapDragEventArgs e )
            {
              if( isDragging )
              {
                e.Handled = true;
              }
            }
    
            private void pushpin_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
            {
              pushpin.CaptureMouse( );
              isDragging = true;
            }
    
            private void pushpin_MouseLeftButtonUp( object sender, MouseButtonEventArgs e )
            {
              pushpin.ReleaseMouseCapture( );
              isDragging = false;
            }
    
            private void pushpin_MouseMove( object sender, MouseEventArgs e )
            {
              pushpin.Location = mapControl.ViewportPointToLocation( e.GetPosition( mapControl) );
            }
