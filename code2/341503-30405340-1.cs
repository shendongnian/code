		[DllImport("shell32.dll", ExactSpelling = true)]
		public static extern void ILFree(IntPtr pidlList);
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern IntPtr ILCreateFromPathW(string pszPath);
		[DllImport("shell32.dll", ExactSpelling = true)]
		public static extern int SHOpenFolderAndSelectItems(IntPtr pidlList, uint cild, IntPtr children, uint dwFlags);
		public void SelectItemInExplorer(string path)
		{
			var pidlList = ILCreateFromPathW(path);
			if(pidlList == IntPtr.Zero)
				throw new Exception(string.Format("ILCreateFromPathW({0}) failed",path));
			try
			{
				Marshal.ThrowExceptionForHR(SHOpenFolderAndSelectItems(pidlList, 0, IntPtr.Zero, 0));
			}
			finally
			{
				ILFree(pidlList);
			}
		}
