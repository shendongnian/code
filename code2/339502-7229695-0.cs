    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4 ||
            Keyboard.Modifiers == ModifierKeys.Control && e.SystemKey == Key.Escape)
        {
            e.Handled = true;
        }
        else
        {
            base.OnKeyDown(e);
        }
    }
