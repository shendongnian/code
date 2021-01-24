        private void CanvasManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            var transform = rectangle.RenderTransform as MatrixTransform;
            var matrix = transform.Matrix;
            Point center = new Point(rectangle.ActualWidth / 2.0, rectangle.ActualHeight / 2.0);
            center = matrix.Transform(center);
            matrix.ScaleAt(e.DeltaManipulation.Scale.X , e.DeltaManipulation.Scale.X, center.X, center.Y);
            matrix.RotateAt(e.DeltaManipulation.Rotation, center.X, center.Y);
            matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);
            rectangle.RenderTransform = new MatrixTransform(matrix);
        }
