    internal static class NativeMethods
    {
        [DllImport("query.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern FilterReturnCodes LoadIFilter(
            string pwcsPath,
            [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
            ref IFilter ppIUnk);
        [DllImport("ole32.dll")]
        public static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out IStream ppstm);
    }
    [ComImport, Guid("89BCB740-6119-101A-BCB7-00DD010655AF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilter
    {
        [PreserveSig]
        FilterReturnCodes Init(FilterInit grfFlags, int cAttributes, IntPtr aAttributes, out FilterFlags pdwFlags);
        [PreserveSig]
        FilterReturnCodes GetChunk(out StatChunk pStat);
        [PreserveSig]
        FilterReturnCodes GetText(
            ref int pcwcBuffer,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder awcBuffer);
        [PreserveSig]
        FilterReturnCodes GetValue(ref IntPtr propVal);
        [PreserveSig]
        FilterReturnCodes BindRegion(ref FilterRegion origPos, ref Guid riid, ref object ppunk);
    }
	
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010c-0000-0000-C000-000000000046")]
    public interface IPersist
    {
        void GetClassID(out Guid pClassID);
    }
	
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000109-0000-0000-C000-000000000046")]
    public interface IPersistStream : IPersist
    {
        new void GetClassID(out Guid pClassID);
        [PreserveSig]
        int IsDirty();
        void Load([In] IStream pStm);
        void Save(
            [In] IStream pStm,
            [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);
        void GetSizeMax(out long pcbSize);
    }
	
	public struct StatChunk
    {
        public int idChunk;
        [MarshalAs(UnmanagedType.U4)]
        public ChunkBreaktype breakType;
        [MarshalAs(UnmanagedType.U4)]
        public ChunkState flags;
        public int locale;
        public FullPropSpec attribute;
        public int idChunkSource;
        public int cwcStartSource;
        public int cwcLenSource;
    }
	
	public enum ChunkBreaktype
    {
        CHUNK_NO_BREAK = 0,
        CHUNK_EOW = 1,
        CHUNK_EOS = 2,
        CHUNK_EOP = 3,
        CHUNK_EOC = 4
    }
	
	public enum ChunkState
    {
        CHUNK_TEXT = 0x1,
        CHUNK_VALUE = 0x2,
        CHUNK_FILTER_OWNED_VALUE = 0x4
    }
	
	[Flags]
    public enum FilterFlags
    {
        IFILTER_FLAGS_OLE_PROPERTIES = 1
    }
	
	[Flags]
    public enum FilterInit
    {
        IFILTER_INIT_CANON_PARAGRAPHS = 1,
        IFILTER_INIT_HARD_LINE_BREAKS = 2,
        IFILTER_INIT_CANON_HYPHENS = 4,
        IFILTER_INIT_CANON_SPACES = 8,
        IFILTER_INIT_APPLY_INDEX_ATTRIBUTES = 16,
        IFILTER_INIT_APPLY_CRAWL_ATTRIBUTES = 256,
        IFILTER_INIT_APPLY_OTHER_ATTRIBUTES = 32,
        IFILTER_INIT_INDEXING_ONLY = 64,
        IFILTER_INIT_SEARCH_LINKS = 128,
        IFILTER_INIT_FILTER_OWNED_VALUE_OK = 512
    }
	
	public struct FilterRegion
    {
        public int idChunk;
        public int cwcStart;
        public int cwcExtent;
    }
	
	public enum FilterReturnCodes : uint
    {
        S_OK = 0,
        E_ACCESSDENIED = 0x80070005,
        E_HANDLE = 0x80070006,
        E_INVALIDARG = 0x80070057,
        E_OUTOFMEMORY = 0x8007000E,
        E_NOTIMPL = 0x80004001,
        E_FAIL = 0x80000008,
        FILTER_E_PASSWORD = 0x8004170B,
        FILTER_E_UNKNOWNFORMAT = 0x8004170C,
        FILTER_E_NO_TEXT = 0x80041705,
        FILTER_E_NO_VALUES = 0x80041706,
        FILTER_E_END_OF_CHUNKS = 0x80041700,
        FILTER_E_NO_MORE_TEXT = 0x80041701,
        FILTER_E_NO_MORE_VALUES = 0x80041702,
        FILTER_E_ACCESS = 0x80041703,
        FILTER_W_MONIKER_CLIPPED = 0x00041704,
        FILTER_E_EMBEDDING_UNAVAILABLE = 0x80041707,
        FILTER_E_LINK_UNAVAILABLE = 0x80041708,
        FILTER_S_LAST_TEXT = 0x00041709,
        FILTER_S_LAST_VALUES = 0x0004170A
    }
	
	public struct FullPropSpec
    {
        public Guid guidPropSet;
		public PropSpec psProperty;
    }
	
	[StructLayout(LayoutKind.Explicit)]
    public struct PropSpec
    {
        [FieldOffset(0)]
        public int ulKind;     
        [FieldOffset(4)]
        public int propid;
        
        [FieldOffset(4)]
        public IntPtr lpwstr;
    }
	
	
