    using System;
    using System.Security.Principal;
    using System.Runtime.InteropServices;
    using AZROLESLib;
    
    namespace TreyResearch {
        public class AzManHelper : IDisposable {
    
            AzAuthorizationStore store;
            IAzApplication app;
            string appName;
    
            public AzManHelper(string connectionString, string appName) {
                
                this.appName = appName;
    
                try {
                    // load and initialize the AzMan runtime
                    store = new AzAuthorizationStore();
                    store.Initialize(0, connectionString, null);
    
                    // drill down to our application
                    app = store.OpenApplication(appName, null);
                }
                catch (COMException x) {
                    throw new AzManException("Failed to initizlize AzManHelper", x);
                }
                catch (System.IO.FileNotFoundException x) {
                    throw new AzManException(string.Format("Failed to load AzMan policy from {0} - make sure your connection string is correct.", connectionString), x);
                }
            }
    
            public void Dispose() {
                if (null == app) return;
    
                Marshal.ReleaseComObject(app);
                Marshal.ReleaseComObject(store);
    
                app = null;
                store = null;
            }
    
            public bool AccessCheck(string audit, Operations op,
                                    WindowsIdentity clientIdentity) {
    
                try {
                    // first step is to create an AzMan context for the client
                    // this looks at the security identifiers (SIDs) in the user's
                    // access token and maps them onto AzMan roles, tasks, and operations
                    IAzClientContext ctx = app.InitializeClientContextFromToken(
                        (ulong)clientIdentity.Token.ToInt64(), null);
    
                    // next step is to see if this user is authorized for
                    // the requested operation. Note that AccessCheck allows
                    // you to check multiple operations at once if you desire
                    object[] scopes = { "" };
                    object[] operations = { (int)op };
                    object[] results = (object[])ctx.AccessCheck(audit, scopes, operations,
                                                                 null, null, null, null, null);
                    int result = (int)results[0];
                    return 0 == result;
                }
                catch (COMException x) {
                    throw new AzManException("AccessCheck failed", x);
                }
            }
    
            public bool AccessCheckWithArg(string audit, Operations op,
                                           WindowsIdentity clientIdentity,
                                           string argName, object argValue) {
    
                try {
                    // first step is to create an AzMan context for the client
                    // this looks at the security identifiers (SIDs) in the user's
                    // access token and maps them onto AzMan roles, tasks, and operations
                    IAzClientContext ctx = app.InitializeClientContextFromToken(
                        (ulong)clientIdentity.Token.ToInt64(), null);
    
                    // next step is to see if this user is authorized for
                    // the requested operation. Note that AccessCheck allows
                    // you to check multiple operations at once if you desire
                    object[] scopes = { "" };
                    object[] operations = { (int)op };
                    object[] argNames = { argName };
                    object[] argValues = { argValue };
                    object[] results = (object[])ctx.AccessCheck(audit, scopes, operations,
                                                                 argNames, argValues,
                                                                 null, null, null);
                    int result = (int)results[0];
                    return 0 == result;
                }
                catch (COMException x) {
                    throw new AzManException("AccessCheckWithArg failed", x);
                }
            }
    
            // use this to update a running app
            // after you change the AzMan policy
            public void UpdateCache() {
                try {
                    store.UpdateCache(null);
                    Marshal.ReleaseComObject(app);
                    app = store.OpenApplication(appName, null);
                }
                catch (COMException x) {
                    throw new AzManException("UpdateCache failed", x);
                }
            }
        }
    
        public class AzManException : Exception {
            public AzManException(string message, Exception innerException)
              : base(message, innerException)
            {}
        }
    }
