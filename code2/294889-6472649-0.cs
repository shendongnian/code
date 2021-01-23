    public class Sample
    {
        DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool EncryptFile(string filename);
        public static void Main ()
        {
            Directory.CreateDirectory("MyEncryptedDirectory");
            EncryptFile("MyEncryptedDirectory");
        }
