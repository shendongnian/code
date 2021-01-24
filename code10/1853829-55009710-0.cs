    public static class LibraryConstants
    {
        public const string DllName = "MyFile.dll";
    }
    public class OtherClass
    {
        [DllImport(LibraryConstants.DllName, CharSet = CharSet.Unicode)]
        public static extern string someFunction(string directory);
    }
