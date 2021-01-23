        public static void AddHook()
        {
            LastKeypress = Tools.UnixTime();
            _keyhookID = SetKeyboardHook(_keyproc);
            _mousehookID = SetKeyboardHook(_mouseproc); // SetMouseHook() here?
        }
