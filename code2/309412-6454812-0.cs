    public struct PDWaveSample
    {
        public bool bValid;                             
        public float fPressure;                         
        public float fDistance;                         
        [MarshalAs(UnmanagedType.LPArray, SizeConst=4)]
        public float[] fVel;
        [MarshalAs(UnmanagedType.LPArray, SizeConst=4)]
        public ushort[] nAmp
    }
    
    public struct PDWaveBurst {
        [MarshalAs(UnmanagedType.LPArray, SizeConst=4096)]
        public float[] fST;
        public float fWinFloor;
        public float fWinCeil;
        public bool bUseWindow;
        public bool bSTOk;
        public bool bGetRawAST;
        public bool bValidBurst;
    }
