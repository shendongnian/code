    using System;
    using System.Text;
    using System.Net;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("iphlpapi.dll", ExactSpelling = true)]
            public static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
    
            static void Main(string[] args)
            {
                IPAddress dst = IPAddress.Parse("192.168.1.149"); // the destination IP address Note:Can Someone give the code to get the IP address of the server
    
                byte[] macAddr = new byte[6];
                uint macAddrLen = (uint)macAddr.Length;
                if (SendARP((int)dst.Address, 0, macAddr, ref macAddrLen) != 0)
                    throw new InvalidOperationException("SendARP failed.");
    
                string[] str = new string[(int)macAddrLen];
                for (int i = 0; i < macAddrLen; i++)
                    str[i] = macAddr[i].ToString("x2");
    
                Console.WriteLine(string.Join(":", str));
            }
        }
    }
