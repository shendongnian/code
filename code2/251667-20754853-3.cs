        using System.Runtime.InteropServices;
        .
        .
        .
        // CITRIX HACK
        // Function used to get the scan code
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("User32.dll")]
        private static extern uint SendInput(uint numberOfInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] input, int structSize);
        /// <summary>
        /// Calls the Win32 SendInput method ...
        /// </summary>
        /// <param name="keyCode">The VirtualKeyCode to press</param>
        public IKeyboardSimulator CITRIXKeyPress(VirtualKeyCode keyCode) //prev public static void
        {
            var down = new INPUT();
            down.Type = (UInt32)InputType.Keyboard;
            down.Data.Keyboard = new KEYBDINPUT();
            down.Data.Keyboard.KeyCode = (UInt16)keyCode; //prev .Keyboard.Vk
            // Scan Code here, was 0
            down.Data.Keyboard.Scan = (ushort)MapVirtualKey((UInt16)keyCode, 0);
            down.Data.Keyboard.Flags = 0;
            down.Data.Keyboard.Time = 0;
            down.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            var up = new INPUT();
            up.Type = (UInt32)InputType.Keyboard;
            up.Data.Keyboard = new KEYBDINPUT();
            up.Data.Keyboard.KeyCode = (UInt16)keyCode;
            // Scan Code here, was 0
            up.Data.Keyboard.Scan = (ushort)MapVirtualKey((UInt16)keyCode, 0);
            up.Data.Keyboard.Flags = (UInt32)KeyboardFlag.KeyUp;
            up.Data.Keyboard.Time = 0;
            up.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            INPUT[] inputList = new INPUT[2];
            inputList[0] = down;
            inputList[1] = up;
            var numberOfSuccessfulSimulatedInputs = SendInput(2,
                 inputList, Marshal.SizeOf(typeof(INPUT)));
            if (numberOfSuccessfulSimulatedInputs == 0)
                throw new Exception(
                string.Format("The key press simulation for {0} was not successful.",
                keyCode));
            return this;
        }
