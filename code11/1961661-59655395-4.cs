        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
        struct SendData
        {
            public UInt32 CmdID;          // 4 bytes       
            public UInt32 code;           // 4 bytes        
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
            private string _description;  // 10 bytes
            
            public string Description
            {
                get
                {
                    return _description;
                }
                set
                {
                    _description = value.Substring(0, 4);
                    
                }
            }
          
