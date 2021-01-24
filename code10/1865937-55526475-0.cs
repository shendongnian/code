        public NativeLibraryLoader(string path32, string path64)
        {
            if (!File.Exists(path32))
                throw new FileNotFoundException("32-bit library not found.", path32);
            if (!File.Exists(path64))
                throw new FileNotFoundException("64-bit library not found.", path64);
            string path;
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    path = path32;
                    break;
                case Architecture.X64:
                    path = path64;
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
            ...
        }
