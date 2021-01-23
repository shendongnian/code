	private void Camera1Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var sendingObj = sender as Canvas;
            if (sendingObj == null) return;
            var elements = VisualTreeHelper
                 .FindElementsInHostCoordinates(
                     e.GetPosition(sendingObj), sendingObj);
            foreach (var l in elements)
            {
                if (l is UserControl)
                {
                    adorn.AdornedElement = l as FrameworkElement;
                    adorn.adorned_MouseLeftButtonDown(l, e);
                    break;
                }
            }
            base.OnMouseLeftButtonDown(e);
        }
