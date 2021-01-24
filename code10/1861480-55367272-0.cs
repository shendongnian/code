    [DllImport("user32.dll", SetLastError = true)]
            private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
    
            private static void SendKeyDown(ushort keyCode)
            {
                var input = new KEYBDINPUT
                {
                    Vk = keyCode
                };
    
                SendKeyboardInput(input);
            }
    
            private static void SendKeyUp(ushort keyCode)
            {
                var input = new KEYBDINPUT
                {
                    Vk = keyCode,
                    Flags = 2
                };
                SendKeyboardInput(input);
            }
    
            private static void SendKeyboardInput(KEYBDINPUT keybInput)
            {
                INPUT input = new INPUT
                {
                    Type = 1
                };
                input.Data.Keyboard = keybInput;
    
                if (SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT))) == 0)
                {
                    throw new Exception();
                }
            }
