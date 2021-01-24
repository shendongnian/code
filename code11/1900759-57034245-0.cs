    try
            {
                System.Diagnostics.Trace.TraceInformation($"HELLO! TRYING TO GET THE CERTIFICATE");
                return new X509Certificate2(File.ReadAllBytes(pfxFilePath), password, sFlags);
            }
            catch (PlatformNotSupportedException ex)
            {
                System.Diagnostics.Trace.TraceError($"HELLO! {ex.Message}");
                if(sFlags.HasFlag(X509KeyStorageFlags.EphemeralKeySet))
                {
                    return GetMyX509Certificate(pfxFilePath,password,X509KeyStorageFlags.MachineKeySet);
                } else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError($"HELLO! {ex.Message}");
                return null;
            }
