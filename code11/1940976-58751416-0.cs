        static bool Check(string s)
        {
            return s.Contains("ErrorText");
        }
        static void Main(string[] args)
        {
            bool b = Check("00:43:00\nErrorText ");
        }
