    /// <summary>Gets the disk free space on a particular volume.</summary>
    /// <param name="lpszPath">Full path of folder on required volume. Must end with a backslash!</param>
    /// <param name="lpFreeBytesAvailable">Free bytes available on the volume for the current user.</param>
    /// <param name="lpTotalNumberOfBytes">Total number of bytes available on the volume for the current user.</param>
    /// <param name="lpTotalNumberOfFreeBytes">Total number of bytes available on the volume for all users.</param>
    /// <returns>True if successful, false on error.</returns>
    [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
    [DllImport("Kernel32", SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetDiskFreeSpaceEx
    (
        string   lpszPath, // Must name a folder.
        out long lpFreeBytesAvailable,
        out long lpTotalNumberOfBytes,
        out long lpTotalNumberOfFreeBytes
    );
