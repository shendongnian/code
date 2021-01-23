    [UnauthorizedAccessException: Access to the registry key 'HKEY_LOCAL_MACHINE\SOFTWARE\XXX\XXX' is denied.]
       Microsoft.Win32.RegistryKey.Win32Error(Int32 errorCode, String str) +3803431
       Microsoft.Win32.RegistryKey.CreateSubKey(String subkey, RegistryKeyPermissionCheck permissionCheck, RegistrySecurity registrySecurity) +743
       webtest.impTest.Page_Load(Object sender, EventArgs e) in D:\VS 2008 Projects\test\webtest\impTest.aspx.cs:28
       System.Web.Util.CalliHelper.EventArgFunctionCaller(IntPtr fp, Object o, Object t, EventArgs e) +25
       System.Web.Util.CalliEventHandlerDelegateProxy.Callback(Object sender, EventArgs e) +42
       System.Web.UI.Control.OnLoad(EventArgs e) +132
       System.Web.UI.Control.LoadRecursive() +66
       System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +2428
 
