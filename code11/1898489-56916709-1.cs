		[DllImport("Winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint waveOutGetNumDevs();
        [DllImport("Winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int waveOutGetDevCaps(IntPtr uDeviceID, out WAVEOUTCAPS pwoc, int cbwoc);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WAVEOUTCAPS
        {
            public ushort wMid;
            public ushort wPid;
            public uint vDriverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPname;
            public int dwFormats;
            public ushort wChannels;
            public ushort wReserved1;
            public int dwSupport;
        }
        [DllImport("Winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int waveOutMessage(IntPtr deviceID, uint uMsg, out uint dwParam1, out uint dwParam2);
        public const int WAVE_MAPPER = (-1);
        public const int MMSYSERR_BASE = 0;
        /* general error return values */
        public const int MMSYSERR_NOERROR = 0;                    /* no error */
        public const int MMSYSERR_ERROR = (MMSYSERR_BASE + 1);  /* unspecified error */
        public const int MMSYSERR_BADDEVICEID = (MMSYSERR_BASE + 2);  /* device ID out of range */
        public const int MMSYSERR_NOTENABLED = (MMSYSERR_BASE + 3);  /* driver failed enable */
        public const int MMSYSERR_ALLOCATED = (MMSYSERR_BASE + 4);  /* device already allocated */
        public const int MMSYSERR_INVALHANDLE = (MMSYSERR_BASE + 5);  /* device handle is invalid */
        public const int MMSYSERR_NODRIVER = (MMSYSERR_BASE + 6);  /* no device driver present */
        public const int MMSYSERR_NOMEM = (MMSYSERR_BASE + 7);  /* memory allocation error */
        public const int MMSYSERR_NOTSUPPORTED = (MMSYSERR_BASE + 8);  /* function isn't supported */
        public const int MMSYSERR_BADERRNUM = (MMSYSERR_BASE + 9);  /* error value out of range */
        public const int MMSYSERR_INVALFLAG = (MMSYSERR_BASE + 10); /* invalid flag passed */
        public const int MMSYSERR_INVALPARAM = (MMSYSERR_BASE + 11); /* invalid parameter passed */
        public const int MMSYSERR_HANDLEBUSY = (MMSYSERR_BASE + 12); /* handle being used simultaneously on another thread (eg callback) */
        public const int MMSYSERR_INVALIDALIAS = (MMSYSERR_BASE + 13); /* specified alias not found */
        public const int MMSYSERR_BADDB = (MMSYSERR_BASE + 14); /* bad registry database */
        public const int MMSYSERR_KEYNOTFOUND = (MMSYSERR_BASE + 15); /* registry key not found */
        public const int MMSYSERR_READERROR = (MMSYSERR_BASE + 16); /* registry read error */
        public const int MMSYSERR_WRITEERROR = (MMSYSERR_BASE + 17); /* registry write error */
        public const int MMSYSERR_DELETEERROR = (MMSYSERR_BASE + 18); /* registry delete error */
        public const int MMSYSERR_VALNOTFOUND = (MMSYSERR_BASE + 19); /* registry value not found */
        public const int MMSYSERR_NODRIVERCB = (MMSYSERR_BASE + 20); /* driver does not call DriverCallback */
        public const int MMSYSERR_MOREDATA = (MMSYSERR_BASE + 21); /* more data to be returned */
        public const int MMSYSERR_LASTERROR = (MMSYSERR_BASE + 21); /* last error in range */
        public const int DRV_RESERVED = 0x0800;
        public const int DRVM_MAPPER = (0x2000);
        public const int DRVM_USER = 0x4000;
        public const int DRVM_MAPPER_STATUS = (DRVM_MAPPER + 0);
        public const int DRVM_MAPPER_RECONFIGURE = (DRVM_MAPPER + 1);
        public const int DRVM_MAPPER_PREFERRED_GET = (DRVM_MAPPER + 21);
        public const int DRVM_MAPPER_CONSOLEVOICECOM_GET = (DRVM_MAPPER + 23);
        public const int DRV_QUERYDEVNODE = (DRV_RESERVED + 2);
        public const int DRV_QUERYMAPPABLE = (DRV_RESERVED + 5);
        public const int DRV_QUERYMODULE = (DRV_RESERVED + 9);
        public const int DRV_PNPINSTALL = (DRV_RESERVED + 11);
        public const int DRV_QUERYDEVICEINTERFACE = (DRV_RESERVED + 12);
        public const int DRV_QUERYDEVICEINTERFACESIZE = (DRV_RESERVED + 13);
        public const int DRV_QUERYSTRINGID = (DRV_RESERVED + 14);
        public const int DRV_QUERYSTRINGIDSIZE = (DRV_RESERVED + 15);
        public const int DRV_QUERYIDFROMSTRINGID = (DRV_RESERVED + 16);
        public const int DRV_QUERYFUNCTIONINSTANCEID = (DRV_RESERVED + 17);
        public const int DRV_QUERYFUNCTIONINSTANCEIDSIZE = (DRV_RESERVED + 18);
        //
        // DRVM_MAPPER_PREFERRED_GET flags
        //
        public const int DRVM_MAPPER_PREFERRED_FLAGS_PREFERREDONLY = 0x00000001;
