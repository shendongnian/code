    private TranslateTransform transform = new TranslateTransform();
        private void root_MouseMove(object sender, MouseEventArgs e)
        {
            if (isInDrag)
            {
                var element = sender as FrameworkElement;
                currentPoint = e.GetPosition(null);
                transform.X += currentPoint.X - anchorPoint.X;
                transform.Y += (currentPoint.Y - anchorPoint.Y);
                if (currentPoint.X < Application.Current.MainWindow.RenderSize.Width && currentPoint.Y < Application.Current.MainWindow.RenderSize.Height
                    && currentPoint.X > 0 && currentPoint.Y > 0 )
                {
                    this.RenderTransform = transform;
                    anchorPoint = currentPoint;
                }
                else
                {
                    transform = new TranslateTransform();
                    this.RenderTransform = transform;
                }
            }
        }
