    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (e.LeftButton == MouseButtonState.Pressed && this.IsPressed == false)
        {
            DragDrop.DoDragDrop(this, this.Content, DragDropEffects.Move);
        }
    }
