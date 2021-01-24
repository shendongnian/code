        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            UIElement thumb = e.Source as UIElement; //find thumb
            Canvas AccessibleArea = ((sender as Control).Parent as Canvas); //find parent Canvas
            if (!(Canvas.GetLeft(thumb) + e.HorizontalChange > AccessibleArea.ActualWidth - (sender as Control).ActualWidth) //do not pass right maximus
                && !((Canvas.GetLeft(thumb) + e.HorizontalChange) <= 0))                                                     //do not pass left minimum
            {
                Canvas.SetLeft(thumb, Canvas.GetLeft(thumb) + e.HorizontalChange);
            }
            if (!(Canvas.GetTop(thumb) + e.VerticalChange > AccessibleArea.ActualHeight - (sender as Control).ActualHeight) // do not pass bottom maximum
                && !((Canvas.GetTop(thumb) + e.VerticalChange) <= 0))                                                       //do not pass top minimum
            {
                Canvas.SetTop(thumb, Canvas.GetTop(thumb) + e.VerticalChange);
            }
        }
