    public class KeyboardStatus
    {
        public KeyboardStatus(Key key, ModifierKeys modifiers)
        {
            _modifiers = modifiers;
        }
        public Key PressedKey { get; set; }
        public bool IsControlPressed { get { return ((_modifiers & ModifierKeys.Control) > 0); } }
        // ....
        public override string ToString()
        {
            string display = string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Control) > 0) ? "Ctrl + " : string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Alt) > 0) ? "Alt + " : string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Shift) > 0) ? "Shift + " : string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Windows) > 0) ? "Win + " : string.Empty;
            display += PressedKey.ToString();
            return display;
        }
        ModifierKeys _modifiers;
    }
