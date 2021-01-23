    private void trackBarFrames_KeyDown(object sender, KeyEventArgs e)
    {
        switch ( e.KeyCode)
        {
            case Keys.Add :
                // Nummeric Keypad Add 
                AddSomething();
                break;
            case Keys.Oemplus :
                // Regular keyboard Add
                // OemPlus is assigned to the regular keyboard key with a "Add" Sign but doesn not take shift conditions in account..!
                if (e.Modifiers == Keys.Shift)
                {
                    AddSomething();
                }
                break;
        }
    }
