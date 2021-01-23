	public static class Dfs
	{
		private enum NetDfsInfoLevel
		{
			DfsInfo1 = 1,
			DfsInfo2 = 2,
			DfsInfo3 = 3,
			DfsInfo4 = 4,
			DfsInfo5 = 5,
			DfsInfo6 = 6,
			DfsInfo7 = 7,
			DfsInfo8 = 8,
			DfsInfo9 = 9,
			DfsInfo50 = 50,
			DfsInfo100 = 100,
			DfsInfo150 = 150,
		}
		[DllImport("netapi32.dll", SetLastError = true)]
		private static extern int NetApiBufferFree(IntPtr buffer);
		[DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern int NetDfsGetInfo(
			[MarshalAs(UnmanagedType.LPWStr)] string DfsEntryPath, // DFS entry path for the volume
			[MarshalAs(UnmanagedType.LPWStr)] string ServerName,   // This parameter is currently ignored and should be NULL
			[MarshalAs(UnmanagedType.LPWStr)] string ShareName,    // This parameter is currently ignored and should be NULL.
			NetDfsInfoLevel Level,                                 // Level of information requested
			out IntPtr Buffer                                      // API allocates and returns buffer with requested info
			);
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct DFS_INFO_3
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string EntryPath;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Comment;
			public int State;
			public int NumberOfStorages;
			public IntPtr Storage;
		}
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct DFS_STORAGE_INFO
		{
			public int State;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string ServerName;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string ShareName;
		}
		private static T GetStruct<T>(IntPtr buffer, int offset=0)where T:struct
		{
			T r = new T();
			r = (T) Marshal.PtrToStructure(buffer + offset * Marshal.SizeOf(r), typeof(T));
			return r;
		}
		public static string GetDfsInfo(string server)
		{
			string rval = null;
			IntPtr b;
			int r = NetDfsGetInfo(server, null, null, NetDfsInfoLevel.DfsInfo3, out b);
			if(r != 0)
			{
				NetApiBufferFree(b);
				// return passed string if not DFS
				return rval;
			}
			
			DFS_INFO_3 sRes = GetStruct<DFS_INFO_3>(b);
			if(sRes.NumberOfStorages > 0)
			{
				DFS_STORAGE_INFO sResInfo = GetStruct<DFS_STORAGE_INFO>(sRes.Storage);
				rval = string.Concat(@"\\", sResInfo.ServerName, @"\", sResInfo.ShareName, @"\");
			}
			NetApiBufferFree(b);
			return rval;
		}
	}
