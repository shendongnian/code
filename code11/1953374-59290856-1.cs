    private void CanvasManipulationDelta(object sender, ManipulationDeltaEventArgs e)
    {
        var transform = (MatrixTransform)rectangle.RenderTransform;
        var matrix = transform.Matrix;
        var center = e.ManipulationOrigin;
        var scale = (e.DeltaManipulation.Scale.X + e.DeltaManipulation.Scale.Y) / 2;
        matrix.ScaleAt(scale, scale, center.X, center.Y);
        matrix.RotateAt(e.DeltaManipulation.Rotation, center.X, center.Y);
        matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);
        transform.Matrix = matrix;
    }
