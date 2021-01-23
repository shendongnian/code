    [ComImport]
    [Guid("EFBAF140-7F42-11CE-BE57-00AA0051FE20")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStemmer
    {
        void Init([MarshalAs(UnmanagedType.U4)] int ulMaxTokenSize, [MarshalAs(UnmanagedType.Bool)] out bool pfLicense);
        void GenerateWordForms([MarshalAs(UnmanagedType.LPWStr)] string pwcInBuf,
            [MarshalAs(UnmanagedType.U4)] int cwc,
            [MarshalAs(UnmanagedType.Interface)] IWordFormSink pStemSink);
        void GetLicenseToUse([MarshalAs(UnmanagedType.LPWStr)] out string ppwcsLicense);
    }
