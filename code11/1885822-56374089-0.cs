    public static class ActiveDirectoryExtensions
    {
        public static DateTime GetLastLogon(this DirectoryEntry entry)
        {
            var activeDirectoryLargeInteger = (IAdsLargeInteger)entry.Properties["lastLogon"].Value;
            return DateTime.FromFileTimeUtc((activeDirectoryLargeInteger.HighPart << 32) + activeDirectoryLargeInteger.LowPart);
        }
        [ComImport, Guid("9068270b-0939-11d1-8be1-00c04fd8d503"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
        internal interface IAdsLargeInteger
        {
            long HighPart { get; set; }
            long LowPart { get; set; }
        }
    }
