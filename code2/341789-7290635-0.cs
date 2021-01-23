    [DllImport("wpcap.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern IntPtr pcap_open(string devicename, int size, int mode, int timeout, IntPtr auth, StringBuilder errbuf);
    
    string devicename = "\\Device\\NPF_{EADB4C21-B0AF-4EF2-86AB-80A37F399D1C}";
    try
    {
       StringBuilder errbuf=new StringBuilder(256);
       iface = pcap_open(devicename, 65536, 1, 1000, IntPtr.Zero, errbuf);
       Console.WriteLine(errbuf.ToString());
    }
    catch (Exception er) { return; }
