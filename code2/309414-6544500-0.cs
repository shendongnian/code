    public struct PDWaveSample
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool bValid;                             
        public float fPressure;                         
        public float fDistance;                         
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public float[] fVel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public ushort[] nAmp
    }
    
    public struct PDWaveBurst {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4096)]
        public float[] fST;
        public float fWinFloor;
        public float fWinCeil;
        [MarshalAs(UnmanagedType.I1)]
        public bool bUseWindow;
        [MarshalAs(UnmanagedType.I1)]
        public bool bSTOk;
        [MarshalAs(UnmanagedType.I1)]
        public bool bGetRawAST;
        [MarshalAs(UnmanagedType.I1)]
        public bool bValidBurst;
    }
    
