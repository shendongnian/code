		private const int RpcServerUnavailable = unchecked((int)0x800706BA);
		private const int RpcCallCancelled = unchecked((int)0x80010002);
		public bool WindowsUp(string hostName)
		{
			string adsiPath = string.Format(@"\\{0}\root\cimv2", hostName);
			ManagementScope scope = new ManagementScope(adsiPath);
			ManagementPath osPath = new ManagementPath("Win32_OperatingSystem");
			ManagementClass os = new ManagementClass(scope, osPath, null);
			ManagementObjectCollection instances = null;
			try
			{
				instances = os.GetInstances();
				return true;
			}
			catch (COMException exception)
			{
				if (exception.ErrorCode == RpcServerUnavailable || exception.ErrorCode == RpcCallCancelled)
				{
					return false;
				}
				throw;
			}
			finally
			{
				if (instances != null)
				{
					instances.Dispose();
					instances = null;
				}
			}
		}
