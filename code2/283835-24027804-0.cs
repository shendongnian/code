    //This will disable "Download signed ActiveX" (IE setting # 0x1001) for Internet Zone (zone #3)
    IInternetZoneManager izm = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("7b8a2d95-0ac9-11d1-896c-00c04Fb6bfc4"))) as IInternetZoneManager;
    IntPtr pPolicy = Marshal.AllocHGlobal(4);
    Marshal.Copy(new int[] { 3 }, 0, pPolicy, 1);//3 means "Disable"
    int result = izm.SetZoneActionPolicy((uint)UrlZone.Internet, (uint)0x1001, pPolicy, 4, (uint)UrlZoneReg.CurrentUserKey);
    Marshal.ReleaseComObject(izm);
    Marshal.FreeHGlobal(pPolicy);
