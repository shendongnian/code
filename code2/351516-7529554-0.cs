    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public struct Attributes
    {
        public OrderCommand Command { get; set; }
        public int RefID { get; set; }
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string MarketSymbol;
    }
