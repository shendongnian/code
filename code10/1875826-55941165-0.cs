        private void StartAnimate_Click(object sender, RoutedEventArgs e)
        {
            var tran = testRectangle.RenderTransform = new ScaleTransform(1d, 1d)
            {
                CenterX = 0.5d,
                CenterY = 0.5d
            };
            var anim = new DoubleAnimation
            {
                To = 1.0,
                From=0,
                Duration = TimeSpan.FromSeconds(0.5d),
                DecelerationRatio = 0.5d,
                FillBehavior = FillBehavior.Stop
            };
            tran.BeginAnimation(
                 ScaleTransform.ScaleYProperty,
                 anim,
                 HandoffBehavior.Compose);
        }
