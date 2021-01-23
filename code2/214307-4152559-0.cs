    // Taken from "Part 2" of the BCL Team Blog
    using System;
    using System.Runtime.InteropServices;
     
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DeleteFile(string lpFileName);
    
    public static void Delete(string fileName) 
    {
        string formattedName = @"\\?\" + fileName;
        DeleteFile(formattedName);
    }
