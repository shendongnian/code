    NEW STRUCTS (BYTES)  
    ////////////////////////////////////////////////////////////////  
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 31)]  
    public struct ConxReq  
    {            
       [FieldOffSet(0)]  
       public byteSubsId;  
       [FieldOffSet(15)]  
       public Int32 Level;  
       [FieldOffSet(19)]  
       public byte Options;  
    }  
    [StructLayout(LayoutKind.Explicit, Size = 4)]        
    public struct ConxNack  
    {            
       [FieldOffSet(0)]  
       public int nReason;  
    }  
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 25)]          
    public struct StartReq  
    {            
       [FieldOffSet(0)]    
       public byte MsgId;  
    }  
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]  
    protected struct Msg  
    {  
      public int Length;  
      public Int16 Type;  
      public Data MsgData;  
    }  
    StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]  
    public struct Data  
    {  
      [FieldOffset(0)]  
      public ConxReq oConxReq;  
      [FieldOffset(0)]  
      public ConxNack oConxNack;  
      [FieldOffset(0)]  
      public StartReq oStartReq;  
    }  
    ////////////////////////////////////////////////////////////////  
    MY ORIGINAL STRUCTS  
    ////////////////////////////////////////////////////////////////  
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]  
    public struct MyConxReq  
    {            
       [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]  
       public string SubsId;  
       public Int32 Level;  
       [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]  
       public string Options;  
    }  
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]         
    public struct MyStartReq  
    {            
       [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]  
       public string MsgId;  
    }  
    [StructLayout(LayoutKind.Sequential)]        
    public struct MyConxNack  
    {            
       public int nReason;  
    }  
    ///////////////////////////////////////////////////////////////  
    Since I have a Msg.Type, i know what kind of struct (type) I could cast the object.  
    Like for example  
    ReceiveMessage(m_Session, nTimeOut, ref oMsg);  
    switch (oMsg.Type)  
    {  
      case 0: // ConxReq  
          IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(oMsg.MsgData.ConxReq); // use the new struct (bytes)  
          Marshal.StructureToPtr(oMsg.MsgData.ConxReq, ptr, false);  
          MyConxReq oMyConxReq = new MyConxReq;  
          oMyConxReq = (MyConxReq) Marshal.PtrToStructure(ptr, typeof(MyConxReq));  // convert it to the original struct  
          Marshal.FreeHGlobal(ptr);  
    Then you can use now the oMyConxReq object to acccess the member variables directly.  
    Please let me know if you have other or better way to do this...
    Please let me know also if what I did is correct or if I missed something.
    Thank you so much!!! :)
