    [Serializable]
    public struct ShortCut
    {
        public bool Shift;
        public bool Alt;
        public bool Ctrl;
    
        public KeyCode Key;
        public bool IsDown => IsCtrlDown && IsAltDown && IsShiftDown && Input.GetKeyDown(Key);
        private bool IsCtrlDown() => !Ctrl || Input.GetKeyDown(KeyCode.RightCtrl || KeyCode.LeftCtrl);
        private bool IsAltDown => !Alt || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt);
        private bool IsShiftDown => !Shift || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
    }
