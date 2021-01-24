        [StructLayout(LayoutKind.Sequential)]
        public struct Responses
        {
            public Int64 MCID;
            public int PanelIdx;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public short[] ResponseValues;
        }
