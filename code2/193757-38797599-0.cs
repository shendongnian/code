	public static class ShellFileGetInfo
	{
		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;
			public IntPtr iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};
		// Enum for return of the file type
		public enum ShellFileType
		{
			FileNotFound,
			Unknown,
			Dos,
			Windows,
			Console
		}
		// Apply the appropriate overlays to the file's icon. The SHGFI_ICON flag must also be set.
		public const uint SHGFI_ADDOVERLAYS = 0x000000020;
		// Modify SHGFI_ATTRIBUTES to indicate that the dwAttributes member of the SHFILEINFO structure at psfi contains the specific attributes that are desired. These attributes are passed to IShellFolder::GetAttributesOf. If this flag is not specified, 0xFFFFFFFF is passed to IShellFolder::GetAttributesOf, requesting all attributes. This flag cannot be specified with the SHGFI_ICON flag.
		public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;
		// Retrieve the item attributes. The attributes are copied to the dwAttributes member of the structure specified in the psfi parameter. These are the same attributes that are obtained from IShellFolder::GetAttributesOf.
		public const uint SHGFI_ATTRIBUTES = 0x000000800;
		// Retrieve the display name for the file, which is the name as it appears in Windows Explorer. The name is copied to the szDisplayName member of the structure specified in psfi. The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name. Note that the display name can be affected by settings such as whether extensions are shown.
		public const uint SHGFI_DISPLAYNAME = 0x000000200;
		// Retrieve the type of the executable file if pszPath identifies an executable file. The information is packed into the return value. This flag cannot be specified with any other flags.
		public const uint SHGFI_EXETYPE = 0x000002000;
		// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list. The handle is copied to the hIcon member of the structure specified by psfi, and the index is copied to the iIcon member.
		public const uint SHGFI_ICON = 0x000000100;
		// Retrieve the name of the file that contains the icon representing the file specified by pszPath, as returned by the IExtractIcon::GetIconLocation method of the file's icon handler. Also retrieve the icon index within that file. The name of the file containing the icon is copied to the szDisplayName member of the structure specified by psfi. The icon's index is copied to that structure's iIcon member.
		public const uint SHGFI_ICONLOCATION = 0x000001000;
		// Modify SHGFI_ICON, causing the function to retrieve the file's large icon. The SHGFI_ICON flag must also be set.
		public const uint SHGFI_LARGEICON = 0x000000000;
		// Modify SHGFI_ICON, causing the function to add the link overlay to the file's icon. The SHGFI_ICON flag must also be set.
		public const uint SHGFI_LINKOVERLAY = 0x000008000;
		// Modify SHGFI_ICON, causing the function to retrieve the file's open icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to return the handle to the system image list that contains the file's small open icon. A container object displays an open icon to indicate that the container is open. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
		public const uint SHGFI_OPENICON = 0x000000002;
		// Version 5.0. Return the index of the overlay icon. The value of the overlay index is returned in the upper eight bits of the iIcon member of the structure specified by psfi. This flag requires that the SHGFI_ICON be set as well.
		public const uint SHGFI_OVERLAYINDEX = 0x000000040;
		// Indicate that pszPath is the address of an ITEMIDLIST structure rather than a path name.
		public const uint SHGFI_PIDL = 0x000000008;
		// Modify SHGFI_ICON, causing the function to blend the file's icon with the system highlight color. The SHGFI_ICON flag must also be set.
		public const uint SHGFI_SELECTED = 0x000010000;
		// Modify SHGFI_ICON, causing the function to retrieve a Shell-sized icon. If this flag is not specified the function sizes the icon according to the system metric values. The SHGFI_ICON flag must also be set.
		public const uint SHGFI_SHELLICONSIZE = 0x000000004;
		// Modify SHGFI_ICON, causing the function to retrieve the file's small icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to return the handle to the system image list that contains small icon images. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
		public const uint SHGFI_SMALLICON = 0x000000001;
		// Retrieve the index of a system image list icon. If successful, the index is copied to the iIcon member of psfi. The return value is a handle to the system image list. Only those images whose indices are successfully copied to iIcon are valid. Attempting to access other images in the system image list will result in undefined behavior.
		public const uint SHGFI_SYSICONINDEX = 0x000004000;
		// Retrieve the string that describes the file's type. The string is copied to the szTypeName member of the structure specified in psfi.
		public const uint SHGFI_TYPENAME = 0x000000400;
		// Indicates that the function should not attempt to access the file specified by pszPath. Rather, it should act as if the file specified by pszPath exists with the file attributes passed in dwFileAttributes. This flag cannot be combined with the SHGFI_ATTRIBUTES, SHGFI_EXETYPE, or SHGFI_PIDL flags.
		public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
	}
