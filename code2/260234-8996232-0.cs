    public static string Account(uint sessionId)
    {
         IntPtr token = IntPtr.Zero;
         String account = String.Empty;
         if (WTSQueryUserToken(sessionId, out token))
         { 
         ...
         ...
