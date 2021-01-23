	private void Camera1Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var sendingObj = sender as Canvas;
            if (sendingObj == null) return;
            foreach (UserControl l in sendingObj.Children)
                {
		            var position = e.GetPosition(l);
                    var lArea = new Rect(0,0,l.ActualWidth,l.ActualHeight);
                    if (lArea.Contains(position))
                    {
                        adorn.AdornedElement = l as FrameworkElement;
                        adorn.adorned_MouseLeftButtonDown(l, e);
                        break;
                    }
                }
             base.OnMouseLeftButtonDown(e);
        }
