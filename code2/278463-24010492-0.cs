    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (!theListBox.Bounds.Contains(e.Location)) 
        {
            theListBox.Visible = false;
        }
    }
