    public class FileUnblocker {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile(string name);
        public bool Unblock(string fileName) {
            return NativeMethods.DeleteFile(fileName);
        }
    }
