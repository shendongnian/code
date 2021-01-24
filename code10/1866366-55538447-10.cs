    public static class KeyEventArgs_Functions
    {
        public static bool Between(this Keys source, Keys lhv, Keys rhv)
        {
            return source >= lhv && source <= rhv;
        }
        public static bool IsLetterKeyBoardChar(this KeyEventArgs source)
        {
            return source.KeyCode.Between(Keys.A, Keys.Z);
        }
        public static bool IsNumberKeyBoardChar(this KeyEventArgs source)
        {
            return !source.Shift && source.KeyCode.Between(Keys.D0, Keys.D9);
        }
        public static bool IsNumber10KeyPadChar(this KeyEventArgs source)
        {
            return source.KeyCode.Between(Keys.NumPad0, Keys.NumPad9);
        }
        public static char ToLetterKeyBoardChar(this KeyEventArgs source) // Only returns a valid value if IsLetterKeyBoardChar returns true.
        {
           return source.Shift ? (char)source.KeyCode: char.ToLower((char)source.KeyCode);
        }
        public static char ToNumberKeyBoardChar(this KeyEventArgs source) // Only returns a valid value if IsNumberKeyBoardChar returns true.
        {
            return (char)source.KeyCode;
        }
        public static char ToNumber10KeyPadChar(this KeyEventArgs source) // Only returns a valid value if IsNumber10KeyPadChar returns true.
        {
            const int DtoNumPadOffset = (int)(Keys.NumPad0 - Keys.D0);
            return (char)((int)source.KeyCode - DtoNumPadOffset);
        }
        public static char? ToAlphaNumericAsciiCharacter(this KeyEventArgs source)
        {
            if (source.IsLetterKeyBoardChar()) return source.ToLetterKeyBoardChar();
            if (source.IsNumberKeyBoardChar()) return source.ToNumberKeyBoardChar();
            if (source.IsNumber10KeyPadChar()) return source.ToNumber10KeyPadChar();
            return null;
        }
    }
