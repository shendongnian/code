    using System.Runtime.InteropServices;
    // IE can be found in COM library called 
    // Microsoft Internet Controls: 
    using IE = SHDocVw.InternetExplorer; 
    static void OpenAndCloseIE()
    {
        // Get an instance of Internet Explorer: 
        Type objClassType = Type.GetTypeFromProgID("InternetExplorer.Application");
        var instance = Activator.CreateInstance(objClassType) as IE;
        // Close Internet Explorer again: 
        instance.Quit();
        // Release instance: 
        System.Runtime.InteropServices.Marshal.ReleaseComObject(instance);
        instance = null; // Don't forget to unreference it. 
    }
