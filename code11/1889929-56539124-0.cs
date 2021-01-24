	using System;
	using System.Runtime.InteropServices;
	
	namespace Util
	{
	    public class ConnectSMB : IDisposable
	    {
	        public string URI { get; private set; }
	        public bool Connected { get; private set; } = false;
	
	        public ConnectSMB(string uri, string username, string password)
	        {
	            string connResult = Native.ConnectToRemote(uri, username, password);
	
	            if (connResult != null)
	            {
	                URI = $"FAILED: {connResult}";
	                Connected = false;
	            }
	            else
	            {
	                URI = uri;
	                Connected = true;
	            }
	        }
	
	        public void Dispose()
	        {
	            Close();
	        }
	
	        public void Close()
	        {
	            if (Connected)
	            {
	                var disconResult = Native.DisconnectRemote(URI);
	                URI = disconResult;
	                Connected = false;
	            }
	        }
	
	        public class Native
	        {
	            #region Consts
	            const int RESOURCETYPE_DISK = 1;
	            const int CONNECT_UPDATE_PROFILE = 0x00000001;
	            #endregion
	
	            #region Errors
	            public enum ENetUseError
	            {
	                NoError = 0,
	                AccessDenied = 5,
	                AlreadyAssigned = 85,
	                BadDevice = 1200,
	                BadNetName = 67,
	                BadProvider = 1204,
	                Cancelled = 1223,
	                ExtendedError = 1208,
	                InvalidAddress = 487,
	                InvalidParameter = 87,
	                InvalidPassword = 1216,
	                MoreData = 234,
	                NoMoreItems = 259,
	                NoNetOrBadPath = 1203,
	                NoNetwork = 1222,
	                BadProfile = 1206,
	                CannotOpenProfile = 1205,
	                DeviceInUse = 2404,
	                NotConnected = 2250,
	                OpenFiles = 2401
	            }
	            #endregion
	
	            #region API methods
	            [DllImport("Mpr.dll")]
	            private static extern ENetUseError WNetUseConnection(
	                IntPtr hwndOwner,
	                NETRESOURCE lpNetResource,
	                string lpPassword,
	                string lpUserID,
	                int dwFlags,
	                string lpAccessName,
	                string lpBufferSize,
	                string lpResult
	            );
	
	            [DllImport("Mpr.dll")]
	            private static extern ENetUseError WNetCancelConnection2(
	                string lpName,
	                int dwFlags,
	                bool fForce
	            );
	
	            [StructLayout(LayoutKind.Sequential)]
	            private class NETRESOURCE
	            {
	                public int dwScope = 0;
	                // Resource Type - disk or printer
	                public int dwType = RESOURCETYPE_DISK;
	                public int dwDisplayType = 0;
	                public int dwUsage = 0;
	                // Local Name - name of local device (optional, not used here)
	                public string lpLocalName = "";
	                // Remote Name - full path to remote share
	                public string lpRemoteName = "";
	                public string lpComment = "";
	                public string lpProvider = "";
	            }
	            #endregion
	
	            public static string ConnectToRemote(string remoteUNC, string username, string password)
	            {
	                NETRESOURCE nr = new NETRESOURCE { lpRemoteName = remoteUNC };
	                ENetUseError ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);
	                return ret == ENetUseError.NoError ? null : ret.ToString();
	            }
	
	            public static string DisconnectRemote(string remoteUNC)
	            {
	                ENetUseError ret = WNetCancelConnection2(remoteUNC, CONNECT_UPDATE_PROFILE, false);
	                if (ret == ENetUseError.NoError) return null;
	                return ret == ENetUseError.NoError ? null : ret.ToString();
	            }
	        }
	    }
	}
