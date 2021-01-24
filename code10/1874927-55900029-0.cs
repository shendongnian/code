        public static class NetworkShare
        {
            /// <summary>
            /// Connects to the remote share
            /// </summary>
            /// <returns>Null if successful, otherwise error message.</returns>
            public static string ConnectToShare(string uri, string username, string password)
            {
                //Create netresource and point it at the share
                var nr = new Netresource
                {
                    dwType = ResourcetypeDisk,
                    lpRemoteName = uri
                };
    
                //Create the share
                var ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);
    
                //Check for errors
                return ret == NoError ? null : GetError(ret);
            }
    
            /// <summary>
            /// Remove the share from cache.
            /// </summary>
            /// <returns>Null if successful, otherwise error message.</returns>
            public static string DisconnectFromShare(string uri, bool force)
            {
                //remove the share
                var ret = WNetCancelConnection(uri, force);
    
                //Check for errors
                return ret == NoError ? null : GetError(ret);
            }
    
            #region P/Invoke Stuff
            [DllImport("Mpr.dll")]
            private static extern int WNetUseConnection(
                IntPtr hwndOwner,
                Netresource lpNetResource,
                string lpPassword,
                string lpUserId,
                int dwFlags,
                string lpAccessName,
                string lpBufferSize,
                string lpResult
                );
    
            [DllImport("Mpr.dll")]
            private static extern int WNetCancelConnection(
                string lpName,
                bool fForce
                );
    
            [StructLayout(LayoutKind.Sequential)]
            private class Netresource
            {
                public int dwScope = 0;
                public int dwType = 0;
                public int dwDisplayType = 0;
                public int dwUsage = 0;
                public string lpLocalName = "";
                public string lpRemoteName = "";
                public string lpComment = "";
                public string lpProvider = "";
            }
    
            #region Consts
            const int ResourcetypeDisk = 0x00000001;
            const int ConnectUpdateProfile = 0x00000001;
            #endregion
    
            #region Errors
            const int NoError = 0;
    
            const int ErrorAccessDenied = 5;
            const int ErrorAlreadyAssigned = 85;
            const int ErrorBadDevice = 1200;
            const int ErrorBadNetName = 67;
            const int ErrorBadProvider = 1204;
            const int ErrorCancelled = 1223;
            const int ErrorExtendedError = 1208;
            const int ErrorInvalidAddress = 487;
            const int ErrorInvalidParameter = 87;
            const int ErrorInvalidPassword = 1216;
            const int ErrorMoreData = 234;
            const int ErrorNoMoreItems = 259;
            const int ErrorNoNetOrBadPath = 1203;
            const int ErrorNoNetwork = 1222;
            const int ErrorSessionCredentialConflict = 1219;
    
            const int ErrorBadProfile = 1206;
            const int ErrorCannotOpenProfile = 1205;
            const int ErrorDeviceInUse = 2404;
            const int ErrorNotConnected = 2250;
            const int ErrorOpenFiles = 2401;
    
            private struct ErrorClass
            {
                public int Num;
                public string Message;
                public ErrorClass(int num, string message)
                {
                    this.Num = num;
                    this.Message = message;
                }
            }
    
            private static readonly ErrorClass[] ErrorList = new ErrorClass[] {
            new ErrorClass(ErrorAccessDenied, "Error: Access Denied"),
            new ErrorClass(ErrorAlreadyAssigned, "Error: Already Assigned"),
            new ErrorClass(ErrorBadDevice, "Error: Bad Device"),
            new ErrorClass(ErrorBadNetName, "Error: Bad Net Name"),
            new ErrorClass(ErrorBadProvider, "Error: Bad Provider"),
            new ErrorClass(ErrorCancelled, "Error: Cancelled"),
            new ErrorClass(ErrorExtendedError, "Error: Extended Error"),
            new ErrorClass(ErrorInvalidAddress, "Error: Invalid Address"),
            new ErrorClass(ErrorInvalidParameter, "Error: Invalid Parameter"),
            new ErrorClass(ErrorInvalidPassword, "Error: Invalid Password"),
            new ErrorClass(ErrorMoreData, "Error: More Data"),
            new ErrorClass(ErrorNoMoreItems, "Error: No More Items"),
            new ErrorClass(ErrorNoNetOrBadPath, "Error: No Net Or Bad Path"),
            new ErrorClass(ErrorNoNetwork, "Error: No Network"),
            new ErrorClass(ErrorBadProfile, "Error: Bad Profile"),
            new ErrorClass(ErrorCannotOpenProfile, "Error: Cannot Open Profile"),
            new ErrorClass(ErrorDeviceInUse, "Error: Device In Use"),
            new ErrorClass(ErrorExtendedError, "Error: Extended Error"),
            new ErrorClass(ErrorNotConnected, "Error: Not Connected"),
            new ErrorClass(ErrorOpenFiles, "Error: Open Files"),
            new ErrorClass(ErrorSessionCredentialConflict, "Error: Credential Conflict"),
        };
    
            private static string GetError(int errNum)
            {
                foreach (var er in ErrorList)
                {
                    if (er.Num == errNum) return er.Message;
                }
                return "Error: Unknown, " + errNum;
            }
            #endregion
    
            #endregion
    
            public static byte[] GetFileBytes(string serverSharedPath,string fileName, string userName, string password)
            {
                DisconnectFromShare($@"{serverSharedPath}", true); //Disconnect in case we are currently connected with our credentials;
                var connectToShare = ConnectToShare($@"{serverSharedPath}", userName, password); //Connect with the new credentials
                if (!string.IsNullOrEmpty(connectToShare))
                    return new byte[0];
                if (!Directory.Exists($@"{serverSharedPath}"))
                    return new byte[0];
                if (!File.Exists($@"{serverSharedPath}\{fileName}"))
                    return new byte[0];
                return File.ReadAllBytes(
                    $@"{serverSharedPath}\{fileName}");
            }
    
            public static bool DeleteFileFromSharedPath(string serverSharedPath, string fileName, string userName,
                string password)
            {
                DisconnectFromShare($@"{serverSharedPath}", true); //Disconnect in case we are currently connected with our credentials;
                var connectToShare = ConnectToShare($@"{serverSharedPath}", userName, password); //Connect with the new credentials
                if (!string.IsNullOrEmpty(connectToShare))
                    return false;
                if (File.Exists($@"{serverSharedPath}\{fileName}"))
                {
                    try
                    {
                        File.Delete($@"{serverSharedPath}\{fileName}");
                        return true;
                    }
                    catch (IOException exception)
                    {
                        return false;
                    }
                }
                return true;
            }
    
            public static bool WriteFileByte(string serverSharedPath, string fileName, byte[] fileBytes, string userName, string password)
            {
                DisconnectFromShare($@"{serverSharedPath}",
                    true); //Disconnect in case we are currently connected with our credentials;
                var connectToShare =
                    ConnectToShare($@"{serverSharedPath}", userName, password); //Connect with the new credentials
                if (!string.IsNullOrEmpty(connectToShare))
                    return false;
                if (!Directory.Exists($@"{serverSharedPath}"))
                    return false;
                if (File.Exists($@"{serverSharedPath}\{fileName}"))
                    File.Delete($@"{serverSharedPath}\{fileName}");
    
                File.WriteAllBytes($@"{serverSharedPath}\{fileName}", fileBytes);
                return true;
            }
    
    
            public static bool IsNetworkConnectivityOk(string serverSharedPath, string userName, string password)
            {
                DisconnectFromShare($@"{serverSharedPath}", true); //Disconnect in case we are currently connected with our credentials;
                var connectToShare = ConnectToShare($@"{serverSharedPath}", userName, password); //Connect with the new credentials
                if (!string.IsNullOrEmpty(connectToShare))
                    return false;
                if (!Directory.Exists($@"{serverSharedPath}"))
                    return false;
                DisconnectFromShare($@"{serverSharedPath}", false); //Disconnect from the server.
                return true;
            }
        }
