    using Outlook = Microsoft.Office.Interop.Outlook;
    object oMissing = System.Reflection.Missing.Value;
    // create outlook object
    Outlook.Application otApp = new Outlook.Application();
    string[] arFunctionParameters =
                { 
                    sTo,
                    sCC,
                    sBCC,
                    sSubject,
                    sBody
                };
    // Run the macro
    otApp.GetType().InvokeMember("FnSendMailSafe",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, otApp, arFunctionParameters);
    System.Runtime.InteropServices.Marshal.ReleaseComObject (otApp);
    otApp = null;
    
    GC.Collect();   //Garbage collection.
