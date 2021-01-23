    private void GestureListener_PinchDelta(object sender, PinchGestureEventArgs e)
        {
            if (e.DistanceRatio < 1.0 || e.DistanceRatio > 1.4)
            {
                return;
            }
            // Create the animation for pinch
            Storyboard storyboard = new Storyboard();
            DoubleAnimation pinchXAnimation = new DoubleAnimation();
            pinchXAnimation.To = e.DistanceRatio;
            pinchXAnimation.Duration = TimeSpan.FromSeconds(0.3);
            storyboard.Children.Add(pinchXAnimation);
            Storyboard.SetTargetProperty(pinchXAnimation, new PropertyPath("GridScaling.ScaleX"));
            Storyboard.SetTarget(pinchXAnimation, GridScaling);
            DoubleAnimation pinchYAnimation = new DoubleAnimation();
            pinchYAnimation.To = e.DistanceRatio;
            pinchYAnimation.Duration = TimeSpan.FromSeconds(0.3);
            storyboard.Children.Add(pinchYAnimation);
            Storyboard.SetTargetProperty(pinchYAnimation, new PropertyPath("GridScaling.ScaleY"));
            Storyboard.SetTarget(pinchYAnimation, GridScaling);
            storyboard.Begin();
        }
