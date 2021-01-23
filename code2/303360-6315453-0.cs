            string keys = "";
            if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
            {
                keys += "Control + ";
            }
            if ((Keyboard.Modifiers & ModifierKeys.Alt) > 0)
            {
                keys += "Alt + ";
            }
            if ((Keyboard.Modifiers & ModifierKeys.Shift) > 0)
            {
                keys += "Shift + ";
            }
            keys += e.Key;
            YourTextBox.Text = keys;
        
