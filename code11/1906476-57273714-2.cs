        class Program
        {
            public static TcAdsClient client;
            static void Main(string[] args)
            {
                
               
                // Create the ADS Client
                using (client = new TcAdsClient())
                {
                    // Establish Connection
                    client.Connect(new AmsAddress("10.1.2.95.1.1", 851));
                    int handle = client.CreateVariableHandle("PRG_AIS.stAds");
    
                    AdsClass ads = (AdsClass)client.ReadAny(handle, typeof(AdsClass));
                    ads.boolArr[0] = 1;
                    client.WriteAny(handle, ads);
                    Console.ReadLine();
    
                }
            }
        }
    
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        class AdsClass
        {
    
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] boolArr = new byte[10];
        }
