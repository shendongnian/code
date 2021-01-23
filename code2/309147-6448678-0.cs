    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //BEGIN
    InternetConnectionState flags = 0;
    int nConnection = 0;
    bool bInternet = InternetGetConnectedState(ref flags,0);
    if (bInternet == false)
    {
     //Not Connected
     if (flags == 0)
     {
       //Do something to tell the user to install some internet connection
     }
     int nResult = InternetDial(IntPtr.Zero,"",(int)InternetDialFlags.INTERNETDIALFORCEPROMPT , ref nConnection , 0);
     switch(nResult)
     {
       case 87://Bad Parameter for InternetDial - Couldn't Connect";
         break;
       case 668://No Connection for InternetDial - Couldn't Connect";
         break;
       case 631://User Cancelled Dialup
         break;
       default://Unknown InternetDial Error
         break;
       case 0://Connection Succeeded
         break;
     }
     //Do whatever you need to do on the internet (send mail etc)
     InternetHangUp(nConnection,0);
     //DONE
    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    [DllImport("wininet.dll",CharSet=CharSet.Auto)]
    static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);
    [Flags]
    enum InternetConnectionState: int
    {
       INTERNETCONNECTIONMODEM = 0x1,
       INTERNETCONNECTIONLAN = 0x2,
       INTERNETCONNECTIONPROXY = 0x4,
       INTERNETRASINSTALLED = 0x10,
       INTERNETCONNECTIONOFFLINE = 0x20,
       INTERNETCONNECTIONCONFIGURED = 0x40
    }
    [DllImport("wininet.dll",CharSet=CharSet.Auto)]
    static extern int InternetDial(IntPtr hwndParent,[MarshalAs(UnmanagedType.LPStr)] string strConnection,[MarshalAs(UnmanagedType.U4)]int dwFlags,ref int dwConnection,int dwReserved);
    [Flags]
    enum InternetDialFlags: int
    {
       INTERNETDIALFORCEPROMPT    =0x2000,
       INTERNETDIALSHOWOFFLINE    =0x4000,
       INTERNETDIAL_UNATTENDED      =0x8000
    }
    [DllImport("wininet.dll",CharSet=CharSet.Auto)]
    static extern int InternetHangup([MarshalAs(UnmanagedType.U4)] int nConnection,[MarshalAs(UnmanagedType.U4)]int dwReserved);
