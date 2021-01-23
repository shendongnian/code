using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
namespace IpInfo
{
    [StructLayout( LayoutKind.Sequential, CharSet=CharSet.Ansi )]
    struct MIB_IPADDRROW 
    {
        public int         _address;
        public int         _index;
        public int         _mask;
        public int         _broadcastAddress;
        public int         _reassemblySize;
        public ushort    _unused1;
        public ushort    _type;
    }
    class Program
    {
        [DllImport("iphlpapi.dll", SetLastError=true)]
        public static extern int GetIpAddrTable(IntPtr pIpAddrTable, ref int pdwSize, bool bOrder);
        static void Main(string[] args)
        {
            IntPtr pBuf = IntPtr.Zero;
            int nBufSize = 0;
            // get the required buffer size            
            GetIpAddrTable( IntPtr.Zero, ref nBufSize, false );
            // allocate the buffer
            pBuf = Marshal.AllocHGlobal( nBufSize );
            try
            {
                int r = GetIpAddrTable(pBuf, ref nBufSize, false);
                if (r != 0)
                    throw new System.ComponentModel.Win32Exception(r);
                int entrySize = Marshal.SizeOf(typeof(MIB_IPADDRROW));
                int nEntries = Marshal.ReadInt32(pBuf);
                int tableStartAddr = (int)pBuf + sizeof(int);
                for (int i = 0; i &lt nEntries; i++)
                {
                    IntPtr pEntry = (IntPtr)(tableStartAddr + i * entrySize);
                    MIB_IPADDRROW addrStruct = (MIB_IPADDRROW)Marshal.PtrToStructure(pEntry, typeof(MIB_IPADDRROW));
                    string ipAddrStr = IPToString(IPAddress.NetworkToHostOrder(addrStruct._address));
                    string ipMaskStr = IPToString(IPAddress.NetworkToHostOrder(addrStruct._mask));
                    Console.WriteLine("IP:" + ipAddrStr + " Mask:" + ipMaskStr);
                }
            }
            finally
            {
                if (pBuf != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pBuf);
                }
            }
        }
        // helper function IPToString
        static string IPToString(int ipaddr)
        {
            return String.Format("{0}.{1}.{2}.{3}",
            (ipaddr >> 24) & 0xFF, (ipaddr >> 16) & 0xFF,
            (ipaddr >> 8) & 0xFF, ipaddr & 0xFF);
        }
    }
}
