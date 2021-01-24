    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("...")]
    [ComVisible(true)]
    public class FileEncryption
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
        public void Decrypt(string filenamewithpath, string password)
        {
            // We manually control memory and free when it is completed
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
            try
            {
                ...
                ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gch.Free();
