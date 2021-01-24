    [Serializable]
    public struct ShortCut
    {
        public bool Ctrl;
        public bool Alt;
        public bool Shift;
    
        public KeyCode Key;
    
        public ShortCut(KeyCode key, bool ctrl, bool alt, bool shift)
        {
            Key = key;
            Ctrl = ctrl;
            Alt = alt;
            Shift = shift;
        }
    
        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Ctrl) builder.Append("CTRL + ");
            if (Alt) builder.Append("ALT + ");
            if (Shift) builder.Append("SHIFT + ");
    
            builder.Append(Key.ToString());
    
            return builder.ToString();
        }
    
        public bool IsDown => IsCtrlDown && IsAltDown && IsShiftDown && Input.GetKeyDown(Key);
    
        private bool IsCtrlDown => !Ctrl || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl);
        private bool IsAltDown => !Alt || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
        private bool IsShiftDown => !Shift || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }
