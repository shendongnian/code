        private static void SafelyDisposeRCSP(RSACryptoServiceProvider rsa, string attemptedOperation)
        {
            // This began happening in Windows 10, inexplicably, with a non-sensical error,
            // "The process cannot access the file because it is being used by another process." or, "Access is denied";
            // procmon determined that the system call generating this exception was all
            // about a file that the rsa object apparently uses under %USERPROFILE%\AppData\... when it tries to rename/move it from
            // Roaming/Microsoft/Crypto/RSA/%USERGUID%/%OBJECTGUID% to Local/Temp/csp%XXXX%.tmp, as if it failed to rename it because
            // it didn't have permission to do so (makes no sense).
            // But why should anyone care?  We're done with the rsa object by now!  
            // Here we just assume this is a serious defect somewhere in the framework.
            // So here we just swallow the exception with a log message, 
            // and that's the only reason for not doing a using block;
            // we could not separate such bogus disposal exceptions from valid exceptions with a "using" block.
            if (rsa != null)
                try { rsa.Clear(); }
                catch (Exception ce) {
                    var msg = "After successfully " + attemptedOperation + ", the RSACryptoServiceProvider.Dispose() method threw a "
                                + ce.GetType().Name;
                    if (ce.Message.StartsWith("Access is denied") ||
                        ce.Message.StartsWith("The process cannot access the file because it is being used by another process."))
                        // note: the ce.Message usually ends with an Environment.NewLine, so we don't need to insert one:
                        Console.WriteLine(msg + ":  " + ce.Message + "Working around this defect in the .NET framework by ignoring the bogus exception.");
                    else {   // Haven't really seen this, not sure why it could happen, but maybe it is because of using a different language?
                        Console.WriteLine("Warning: " + msg);
                        Console.WriteLine(ce.ToString()); // we will log the full stack trace just in case it is important to investigate
                    }
                }
        }
You could also conjoin that disjunctive condition (in the "if" statement) with ```ce is CryptographicException```, but I saw little point in adding that.
Example of using it:
        public static byte[] CreateRSAKey() {
            RSACryptoServiceProvider rcsp = null;
            try {
                rcsp = new RSACryptoServiceProvider();
                return rcsp.ExportCspBlob(true);
            } finally {
                SafelyDisposeRCSP(rcsp, "exporting key");
            }
        }
        // ...
        public static ... Encrypt(...) {
        // ...
            } finally {
                SafelyDisposeRCSP(rcsp, "encrypting string");
            }
        // ...
        // ... etc. ...
