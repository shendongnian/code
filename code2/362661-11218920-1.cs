    protected override void OnMouseWheel(MouseEventArgs e)
    {
        if (this.VScroll && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
        {
            this.VScroll = false;
            base.OnMouseWheel(e);
            this.VScroll = true;
        }
        else
        {
            base.OnMouseWheel(e);
        }
    }
