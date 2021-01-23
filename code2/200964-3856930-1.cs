    Point capturePoint { get; set; }
        private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            scrollViewer.CaptureMouse();
            capturePoint = e.MouseDevice.GetPosition(scrollViewer);
        }
        private void ScrollViewer_MouseUp(object sender, MouseButtonEventArgs e) {
            scrollViewer.ReleaseMouseCapture();
        }
        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e) {
            if (!scrollViewer.IsMouseCaptured) return;
            Point currentPoint = e.MouseDevice.GetPosition(scrollViewer);
            var deltaX = capturePoint.X - currentPoint.X;
            var deltaY = capturePoint.Y - currentPoint.Y;
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + deltaX);
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + deltaY);
        }
