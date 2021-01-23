    using System.Runtime.InteropServices;
    [DllImport(
        @"C:\Users\Ron\Documents\Visual Studio 2013\ etc. ...(The whole path)... my.dll,
        CallingConvention = CallingConvention.Cdecl
        )]
    [return: MarshalAs(UnmanagedType.BStr)]
    public static extern string cpp_brand_files(string home_dir, string xml_lic);
