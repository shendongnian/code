    public bool Matches(ref Message m)
    {
        Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
        ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);
        if ((key == Key) &&
            (modifier == Modifier))
        {
            return true;
        }
        return false;
    }
