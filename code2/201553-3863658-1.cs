        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        private struct Example {
            public int mumble;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 42)]
            public string text;
            // etc...
        }
