    [StructLayout(LayoutKind.Sequential)]
    internal struct snes_ntsc_setup_t
    {
    	[MarshalAs(UnmanagedType.R8)] public double hue;
    	[MarshalAs(UnmanagedType.R8)] public double saturation;
    	[MarshalAs(UnmanagedType.R8)] public double contrast;
    	[MarshalAs(UnmanagedType.R8)] public double brightness;
    	[MarshalAs(UnmanagedType.R8)] public double sharpness;
    
    	[MarshalAs(UnmanagedType.R8)] public double gamma;
    	[MarshalAs(UnmanagedType.R8)] public double resolution;
    	[MarshalAs(UnmanagedType.R8)] public double artifacts;
    	[MarshalAs(UnmanagedType.R8)] public double fringing;
    	[MarshalAs(UnmanagedType.R8)] public double bleed;
    	[MarshalAs(UnmanagedType.I4)] public int merge_fields;
    	[MarshalAs(UnmanagedType.SysInt)] public IntPtr decoder_matrix;
    
    	[MarshalAs(UnmanagedType.SysInt)] public IntPtr bsnes_colortbl;
    }
