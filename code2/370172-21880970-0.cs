    private void UIElement_OnPreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (e.StylusDevice != null)
        {
            AddInfoItem("Stylus or Touch recognized");
            e.Handled = true;
            return;
        }
        AddInfoItem("No Stylus or Touch recognized");
    }
