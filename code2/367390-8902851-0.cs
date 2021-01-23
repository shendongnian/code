    // namespace declaration
    using System.Management;
     
    // code sample for setting default printer
     
    ManagementObjectCollection objManagementColl;
    // class used to invoke the query for specified management collection
    ManagementObjectSearcher objManagementSearch = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
     
    // invokes the specified query and returns the resulting collection
    objManagementColl = objManagementSearch.Get();
     
    foreach(ManagementObject objManage in objManagementColl)
        {
           if (objManage["Name"].ToString() == "RequiredPrinterName")  // compares the name of printers
              {
                 objManage.InvokeMethod("SetDefaultPrinter", null); // invoke [SetDefaultPrinter] method 
                 break;
               }
          }
     
