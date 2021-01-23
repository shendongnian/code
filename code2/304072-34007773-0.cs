    public int OStype()
        {
            int os = 0;
            IEnumerable<string> list64 = Directory.GetDirectories(Environment.GetEnvironmentVariable("SystemRoot")).Where(s => s.Equals(@"C:\Windows\SysWOW64"));
            IEnumerable<string> list32 = Directory.GetDirectories(Environment.GetEnvironmentVariable("SystemRoot")).Where(s => s.Equals(@"C:\Windows\System32"));
            if (list32.Count() > 0)
            {
                os = 32;
                if (list64.Count() > 0)
                    os = 64;
            }
            return os;
        }
