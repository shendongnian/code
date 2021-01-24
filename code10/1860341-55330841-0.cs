    using Microsoft.Toolkit.Uwp.UI.Animations;
    private void scrollViewer_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
    {
        var doubleTapPoint = e.GetPosition(ImageScrollViewer);
    
         // zoom in
        if (zoomFactor == 1)
        {
             zoomFactor = 2;
    
             MainPageImage.Scale(centerX: (float)doubleTapPoint.X,
                     centerY: (float)doubleTapPoint.Y,
                     scaleX: 2.0f,
                     scaleY: 2.0f,
                     duration: 500, delay: 0).StartAsync();
    
            
        }
         // zoom out
         else
        {
             zoomFactor = 1;
             MainPageImage.Scale(centerX: (float)doubleTapPoint.X,
                      centerY: (float)doubleTapPoint.Y,
                      scaleX: 1.0f,
                      scaleY: 1.0f,
                      duration: 500, delay: 0).StartAsync();
          
        }
    }
