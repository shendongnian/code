    bool isRKeyPressed = e.KeyChar == (char)Keys.R;
    bool isControlKeyPressed = (Control.ModifierKeys & Keys.Control) == Keys.Control;
    if (isRKeyPressed && isControlKeyPressed)
    {
        // Both ...
    }
    else if (isRKeyPressed)
    {
        // R key only ...
    }
    else if (isControlKeyPressed)
    {
        // CTRL key only ...
    }
    else
    {
        // None of these...
    }
