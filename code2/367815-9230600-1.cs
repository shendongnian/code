        public void KeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D0)
            {
                ControlZero();
            }
        }
