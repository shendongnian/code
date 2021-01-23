    private static void ApplyOrientationTransform(PageOrientation orientation, FrameworkElement popupContent)
    {
      TransformGroup group;
    
      switch (orientation)
      {
        case PageOrientation.LandscapeRight:
          group = new TransformGroup();
          group.Children.Add(new TranslateTransform { X = -popupContent.ActualWidth / 2, Y = -popupContent.ActualHeight / 2 });
          group.Children.Add(new RotateTransform {CenterX = 0, CenterY = 0, Angle = -90});
          group.Children.Add(new TranslateTransform { X = popupContent.ActualWidth / 2, Y = popupContent.ActualHeight / 2 });
          popupContent.RenderTransform = group;
          break;
        case PageOrientation.LandscapeLeft:
          group = new TransformGroup();
          group.Children.Add(new TranslateTransform { X = -popupContent.ActualWidth / 2, Y = -popupContent.ActualHeight / 2 });
          group.Children.Add(new RotateTransform {CenterX = 0, CenterY = 0, Angle = 90});
          group.Children.Add(new TranslateTransform { X = popupContent.ActualWidth / 2, Y = popupContent.ActualHeight / 2 });
          popupContent.RenderTransform = group;
          break;
        default:
          popupContent.RenderTransform = null;
          break;
      }
    }
