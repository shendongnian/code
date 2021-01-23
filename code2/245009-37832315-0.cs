	public static string[] GetPrinterNames()
	{
		var results = new List<string>();
		foreach (PRINTER_INFO_2 info in enumPrinters(PrinterEnumFlags.PRINTER_ENUM_LOCAL | PrinterEnumFlags.PRINTER_ENUM_NETWORK))
			results.Add(info.pPrinterName);
		return results.ToArray();
	}
	
	private static PRINTER_INFO_2[] enumPrinters(PrinterEnumFlags Flags)
	{
		uint cbNeeded = 0;
		uint cReturned = 0;
		if (EnumPrinters(Flags, null, 2, IntPtr.Zero, 0, ref cbNeeded, ref cReturned))
		{
			return null;
		}
		int lastWin32Error = Marshal.GetLastWin32Error();
		if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
		{
			IntPtr pAddr = Marshal.AllocHGlobal((int)cbNeeded);
			if (EnumPrinters(Flags, null, 2, pAddr, cbNeeded, ref cbNeeded, ref cReturned))
			{
				PRINTER_INFO_2[] printerInfo2 = new PRINTER_INFO_2[cReturned];
				long offset = pAddr.ToInt64();
				Type type = typeof(PRINTER_INFO_2);
				int increment = Marshal.SizeOf(type);
				for (int i = 0; i < cReturned; i++)
				{
					printerInfo2[i] = (PRINTER_INFO_2)Marshal.PtrToStructure(new IntPtr(offset), type);
					offset += increment;
				}
				Marshal.FreeHGlobal(pAddr);
				return printerInfo2;
			}
			lastWin32Error = Marshal.GetLastWin32Error();
		}
		throw new System.ComponentModel.Win32Exception(lastWin32Error);
	}
	
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct PRINTER_INFO_2
	{
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pServerName;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pShareName;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPortName;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverName;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pComment;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pLocation;
		public IntPtr pDevMode;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pSepFile;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrintProcessor;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pParameters;
		public IntPtr pSecurityDescriptor;
		public uint Attributes;
		public uint Priority;
		public uint DefaultPriority;
		public uint StartTime;
		public uint UntilTime;
		public uint Status;
		public uint cJobs;
		public uint AveragePPM;
	}
	
	const int ERROR_INSUFFICIENT_BUFFER = 122;
	
	[FlagsAttribute]
	enum PrinterEnumFlags
	{
		PRINTER_ENUM_DEFAULT = 0x00000001,
		PRINTER_ENUM_LOCAL = 0x00000002,
		PRINTER_ENUM_CONNECTIONS = 0x00000004,
		PRINTER_ENUM_FAVORITE = 0x00000004,
		PRINTER_ENUM_NAME = 0x00000008,
		PRINTER_ENUM_REMOTE = 0x00000010,
		PRINTER_ENUM_SHARED = 0x00000020,
		PRINTER_ENUM_NETWORK = 0x00000040,
		PRINTER_ENUM_EXPAND = 0x00004000,
		PRINTER_ENUM_CONTAINER = 0x00008000,
		PRINTER_ENUM_ICONMASK = 0x00ff0000,
		PRINTER_ENUM_ICON1 = 0x00010000,
		PRINTER_ENUM_ICON2 = 0x00020000,
		PRINTER_ENUM_ICON3 = 0x00040000,
		PRINTER_ENUM_ICON4 = 0x00080000,
		PRINTER_ENUM_ICON5 = 0x00100000,
		PRINTER_ENUM_ICON6 = 0x00200000,
		PRINTER_ENUM_ICON7 = 0x00400000,
		PRINTER_ENUM_ICON8 = 0x00800000,
		PRINTER_ENUM_HIDE = 0x01000000
	}
	
	[DllImport("winspool.drv", SetLastError = true)]
	static extern bool EnumPrintersW(Int32 flags, [MarshalAs(UnmanagedType.LPTStr)] string printerName,
					 Int32 level, IntPtr buffer, Int32 bufferSize, out Int32 requiredBufferSize,
					 out Int32 numPrintersReturned);
	
	[DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool EnumPrinters(PrinterEnumFlags Flags, string Name, uint Level, IntPtr pPrinterEnum, uint cbBuf, ref uint pcbNeeded, ref uint pcReturned);
