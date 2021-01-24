    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public struct _tagGPSMDVRInfo
    {
        //struct now in proper sequence 
        [MarshalAs(UnmanagedType.I4)]
        public int nID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szIDNO;// <--- Now in correct position.... 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szName;
        [MarshalAs(UnmanagedType.I4)]
        public int nJingDu;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string strReserve;
    }
    static void FUNDownDevCBEx(int nType, IntPtr pData, Form1 form1)
    {
        try
        {
            switch (nType)
            {
                case 0:
                    _tagGPSMDVRInfo p = new _tagGPSMDVRInfo(); // Create the managed struct
                    p = Marshal.PtrToStructure<_tagGPSMDVRInfo>(pData);//simplify
                    int nID = p.nID;
                    string szIDNO = p.szIDNO;
                    form1.Invoke((MethodInvoker)(() => form1.textBox4.AppendText(" DATA =" + pData + " nID=" + nID + " szIDNO=" + szIDNO + Environment.NewLine)));
                    ;
                    break;
                case 1:
                    //MessageBox.Show("GPS_DEV_DOWN_GROUP" + Environment.NewLine + " DATA =" + pData + " nID=" + nID);
                    break;
                case 2:
                    //MessageBox.Show("GPS_DEV_DOWN_FAILED" + Environment.NewLine + " DATA =" + pData );
                    break;
                case 3:
                    //MessageBox.Show("GPS_DEV_DOWN_SUC" + Environment.NewLine + " DATA =" + pData);
                    break;
                case 4:
                    //MessageBox.Show("GPS_DEV_DOWN_RELATION" + Environment.NewLine + " DATA =" + pData + " nID=" + nID);
                    break;
                default:
                    //MessageBox.Show("DEFAULT");
                    break;
            }
            //MessageBox.Show("nType= " + nType + " pData= " + pData);
            NETClass.NETCLIENT_DEVStopDevDownEx(IntPtr.Zero);
            NETClass.NETCLIENT_DEVCloseDevDownEx(IntPtr.Zero);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "FUNDownDevCBEx Exception");
            return;
        }
    }
