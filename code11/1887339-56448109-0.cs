    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("...")]
    [ComVisible(true)]
    public class FileEncryption
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
