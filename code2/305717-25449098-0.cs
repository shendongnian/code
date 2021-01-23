    using Microsoft.Win32;
    String strOSProductType = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\ProductOptions", 
                                                "ProductType", 
                                                "Key doesn't Exist" ).ToString() ;
    if( strOSProductType == "ServerNT" )
    {
        //Windows Server
    }
    else if( strOsProductType == "WinNT" )
    {
        //Windows Workstation
    }
