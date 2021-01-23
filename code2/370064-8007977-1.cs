    private void Mover_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
    {
        Canvas.SetLeft(DragThumb, Canvas.GetLeft(DragThumb) + e.HorizontalChange);
        Canvas.SetTop(DragThumb, Canvas.GetTop(DragThumb) + e.VerticalChange);
    }
