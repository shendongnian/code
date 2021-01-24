        [DllImport("Project3.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool EncryptData(
            byte* szData, char* szPassword, StringBuilder sbError, byte* pData, byte* pDataLen, bool Encrypt);
        static unsafe void Main(string[] args)
        {
            StringBuilder sbError = new StringBuilder(255);
            byte[] szDataBuff = Encoding.ASCII.GetBytes("datatest");
            char[] szPasswordBuff = ("test").ToCharArray();
            byte[] pDataBuff = new byte[1008];
            byte[] pDataLenBuff = new byte[16];
            fixed (byte* szData = szDataBuff)
            fixed (char* szPassword = szPasswordBuff)
            fixed (byte* pData = pDataBuff)
            fixed (byte* pDataLen = pDataLenBuff)
            {
                Console.WriteLine("Encrypt");
                bool bRet = EncryptData(szData, szPassword, sbError, pData, pDataLen, true);
                Console.WriteLine("Encrypted: {0}", bRet);
                Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)pData));
                Console.WriteLine("Decrypt");
                bool bRet2 = EncryptData(szData, szPassword, sbError, pData, pDataLen, false);
                Console.WriteLine("Derypted: {0}", bRet2);
                Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)pData));
            }
            Console.ReadKey();
        }
