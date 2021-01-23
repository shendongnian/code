    private void ShowAdorner( ) {
      Owner.HideAppointmentAdorners( );
      AdornerLayer layer = AdornerLayer.GetAdornerLayer( this );
      Adorner []adorners = layer.GetAdorners( this );
      if( adorners == null || adorners.Length == 0 )
      {
          layer.Add( new ResizingAdorner( this ) { Visibility = System.Windows.Visibility.Visible } );
      }
      else
      {
          for( int i = 0; i < adorners.Length; i++ )
          {
              adorners [ i ].Visibility = System.Windows.Visibility.Visible;
          }
      }
  }
