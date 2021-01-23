    typedef sequence<octet> LicenseFileData;
    
    interface LicenseInfo
    {
      boolean IsUserLicensed(in wstring wstrUser, in wstring wstrModule, in wstring wstrInstallNo);
      long GetHardwareKey(out wstring pbstrHK);
      long GetInstallationNumberList(out wstring wbstrInstNum);
      long GetSystemNumber(out wstring wbstrSysNum, in wstring wstrInstallNo);
      long GetLicenseInfo(in wstring wstrModule, out long lNum, out long lAvailable, out long lStart, out long lEnd, in wstring wstrInstallNo);
      long GetLoggedInUsers(out wstring wbstrLogUsers);
      long StartLogging();
      long StopLogging();
      long GetLicenseNum(in wstring wstrKey, in wstring wstrInstallNo);
      long GetLogFileName(out wstring wstrLogFileName);
      boolean GetIsLogging();
      long LoadLicenseFile (in LicenseFileData arg_licenseFileData);
      boolean IsLicenseFileExist();
      long ResetAllLicenses();
      long GetVersion(out wstring sVersion);
      //long DeleteLicenseFile (in wstring wstrInstallNo);
    };
