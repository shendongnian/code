    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
     
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    internal static extern IntPtr FindFirstFile(string lpFileName, out
                                    WIN32_FIND_DATA lpFindFileData);
     
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    internal static extern bool FindNextFile(IntPtr hFindFile, out
                                    WIN32_FIND_DATA lpFindFileData);
     
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool FindClose(IntPtr hFindFile);
     
    // Assume dirName passed in is already prefixed with \\?\
    public static IEnumerable<string> EnumerateEntries(string directory)
    { 
        WIN32_FIND_DATA findData;
        IntPtr findHandle = FindFirstFile(dirName + @"\*", out findData);
     
        try
        {
            if (findHandle != INVALID_HANDLE_VALUE)
            {
                bool found;
                do
                {
                    string currentFileName = findData.cFileName;
     
                    // if this is a directory, find its contents
                    if (((int)findData.dwFileAttributes &
                                    FILE_ATTRIBUTE_DIRECTORY) != 0)
                    {
                        if (currentFileName != "." && currentFileName != "..")
                        {
                            foreach(var child in FindFilesAndDirs(
                                    Path.Combine(dirName, currentFileName))
                            {
                                yield return child;
                            }
                        }
                    }
                    yield return Path.Combine(dirName, currentFileName);
     
                    // find next
                    found = FindNextFile(findHandle, out findData);
                }
                while (found);
            }
            
        }
        finally
        {
            // close the find handle
            FindClose(findHandle);
        }
    }
