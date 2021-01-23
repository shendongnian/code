        [DllImportAttribute("User32.dll")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpChar, int uFlags);
        [DllImportAttribute("User32.dll")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        
        public static char GetAsciiCharacter(int uVirtKey, int uScanCode)
        {
            byte[] lpKeyState = new byte[256];
            GetKeyboardState(lpKeyState);
            byte[] lpChar = new byte[2];
            if (ToAscii(uVirtKey, uScanCode, lpKeyState, lpChar, 0) == 1)
                return (char)lpChar[0];
            else
                return new char();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.ShiftKey || keyData == Keys.Shift)
                return base.ProcessCmdKey(ref msg, keyData);
            char keyChar = GetAsciiCharacter((int) (keyData & Keys.KeyCode), (((int) msg.LParam) & 0x1000000));
       
            if(keyChar == '\0')
                return base.ProcessCmdKey(ref msg, keyData);
            _currentSequence.Add(keyChar);
            if (_currentSequence.ToString() == "^~{")
            {
                _handlingInputFromScanner = true;
                _scannerBuffer.Clear();
                return true;
            }
            if (_currentSequence.ToString() == "}~^")
            {
                _handlingInputFromScanner = false;
                OnScannerRead.Invoke(this, new ScannerReadEventArgs { ScannerData = _scannerBuffer.ToString() });
                _scannerBuffer.Clear();
                return true;
            }
            if (keyChar == '}' || keyChar == '{' || keyChar == '~' || keyChar == '^')
            {
                return true;
            }
            if (_handlingInputFromScanner)
            {
                _scannerBuffer.Append(keyChar);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
