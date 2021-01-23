    public class MyClass
    {
        [DLLImport("kernel32")]
        private static extern long WritePrivateProfileString(string sectio, string key, string val, string filePath);
        public MyClass()
        {
        }
        public void foo()
        {
        }
        // etc, etc
    }
        
