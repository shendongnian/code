    public static class DnsAddr
    {
        [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)]ref string pszName, QueryTypes wType, QueryOptions options, int         aipServers, ref IntPtr ppQueryResults, int pReserved);
        [DllImport("dnsapi", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void DnsRecordListFree(IntPtr pRecordList, int FreeType);
        public static IEnumerable<IPAddress> GetAddress(string domain)
        {
            IntPtr ptr1 = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            List<IPAddress> list = new List<IPAddress>();
            DnsRecord record = new DnsRecord();
            int num1 = DnsAddr.DnsQuery(ref domain, QueryTypes.DNS_TYPE_A, QueryOptions.DNS_QUERY_NONE, 0, ref ptr1, 0);
            if (num1 != 0)
                throw new Win32Exception(num1);
            for (ptr2 = ptr1; !ptr2.Equals(IntPtr.Zero); ptr2 = record.pNext)
            {
                record = (DnsRecord)Marshal.PtrToStructure(ptr2, typeof(DnsRecord));
                list.Add(new IPAddress(record.ipAddress));
            }
            DnsAddr.DnsRecordListFree(ptr1, 0);
            return list;
        }
        private enum QueryOptions
        {     
            DNS_QUERY_NONE = 0,
        }
        private enum QueryTypes
        {
            DNS_TYPE_A = 1,
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct DnsRecord
        {
            public IntPtr pNext;
            public string pName;
            public short wType;
            public short wDataLength;
            public int flags;
            public int dwTtl;
            public int dwReserved;
            public uint ipAddress;
        }
    }
