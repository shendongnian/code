    // Used: http://www.pinvoke.net/default.aspx/user32.getasynckeystate
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Win32.Devices
    {
        public class Keyboard
        {
            [DllImport("user32.dll")]
            static extern ushort GetAsyncKeyState(Keys vKey);
    
            public static bool IsKeyDown(Keys key)
            {
                return 0 != (GetAsyncKeyState(key) & 0x8000);
            }
        }
    }
