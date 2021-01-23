    internal sealed class Test
    {
        [DllImport("testlib.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr DataReceived(byte[] signals);
    
    }
