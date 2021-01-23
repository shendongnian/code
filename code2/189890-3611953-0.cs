        [DllImport("search.dll")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool searchEvent(
            int channel,
            ref int condition,
            [MarshalAs(UnmanagedType.U1)] bool next
        );
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct Mumble {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string version;
            public long time;
            public IntPtr minute;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX)]
            public ushort _dwell[];
        }
