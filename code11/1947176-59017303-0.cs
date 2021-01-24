    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            const int SB_OEM_HEADER_SIZE = 10;
            const int SB_OEM_DEV_ID_SIZE = 10;
            const int SB_OEM_CHK_SUM_SIZE = 10;
            static void Main(string[] args)
            {
                int nSize = 1024;
                byte[] nBuf = new byte[nSize];
                byte[] Buf = new byte[SB_OEM_HEADER_SIZE + SB_OEM_DEV_ID_SIZE];
                IntPtr pCommBuf = Marshal.AllocHGlobal(nSize + SB_OEM_HEADER_SIZE + SB_OEM_DEV_ID_SIZE + SB_OEM_CHK_SUM_SIZE);
                Marshal.Copy(nBuf, 0, pCommBuf, nSize);
                Marshal.Copy(pCommBuf, Buf, nSize, (int)(SB_OEM_HEADER_SIZE + SB_OEM_DEV_ID_SIZE));
            }
        }
    }
