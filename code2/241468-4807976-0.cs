    public class KeyMapper
    {
        /// <summary>
        /// Map key code to character.
        /// If key code cannot be mapped returns empty char.
        /// </summary>
        public static char MapKey(Key key, bool shiftPressed, string culture)
        {
            CheckCulture(culture);
            int englishVirtuaCode = KeyInterop.VirtualKeyFromKey(key);
            return EnglishVirtualCodeToChar(englishVirtuaCode, shiftPressed, culture);
        }
        private static void CheckCulture(string culture)
        {
            InputLanguage language = InputLanguage.FromCulture(new CultureInfo(culture));
            if (language == null)
                throw new ArgumentException(string.Format("culture {0} does not exist.", culture));
        }
        private static char EnglishVirtualCodeToChar(int enlishVirtualCode, bool shiftPressed, string culture)
        {
            var scanCode = KeyMappingWinApi.MapVirtualKeyEx((uint)enlishVirtualCode, 0, EnglishCultureHandle);
            var vitualKeyCode = KeyMappingWinApi.MapVirtualKeyEx(scanCode, 1, GetCultureHandle(culture));
            byte[] keyStates = GetKeyStates(vitualKeyCode, shiftPressed);
            const int keyInformationSize = 5;
            var stringBuilder = new StringBuilder(keyInformationSize);
            KeyMappingWinApi.ToUnicodeEx(vitualKeyCode, scanCode, keyStates, stringBuilder, stringBuilder.Capacity, 0, GetCultureHandle(culture));
            if (stringBuilder.Length == 0)
                return ' ';
            return stringBuilder[0];
        }
        private static IntPtr EnglishCultureHandle
        {
            get { return GetCultureHandle("en-US"); }
        }
        private static IntPtr GetCultureHandle(string culture)
        {
            return InputLanguage.FromCulture(new CultureInfo(culture)).Handle;
        }
        /// <summary>
        /// Gets key states for ToUnicodeEx function
        /// </summary>
        private static byte[] GetKeyStates(uint keyCode, bool shiftPressed)
        {
            const byte keyPressFlag = 0x80;
            const byte shifPosition = 16; // position of Shift key in keys array
            var keyStatses = new byte[256];
            keyStatses[keyCode] = keyPressFlag;
            keyStatses[shifPosition] = shiftPressed ? keyPressFlag : (byte)0;
            return keyStatses;
        }
    }
    public class KeyMappingWinApi
    {
        [DllImport("user32.dll")]
        public static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);
        [DllImport("user32.dll")]
        public static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
        [DllImport("user32.dll")]
        public static extern short VkKeyScanEx(char ch, IntPtr dwhkl);
    }
