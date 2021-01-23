    void Fake() {
      bool ok = false;
      ConnectionOptions cOpts = new ConnectionOptions();
      ManagementObjectCollection moCollection;
      ManagementObjectSearcher moSearcher;
      ManagementScope mScope;
      ObjectQuery oQuery;
      if (cOpts != null) {
        mScope = new ManagementScope(String.Format("\\\\{0}\\{1}", host.hostname, "ROOT\\CIMV2"), cOpts);
        if (mScope != null) {
          oQuery = new ObjectQuery("Select * from Win32_OperatingSystem");
          if (oQuery != null) {
            moSearcher = new ManagementObjectSearcher(mScope, oQuery);
            if (moSearcher != null) {
              ManualResetEvent mre = new ManualResetEvent(false);
              Thread thread1 = new Thread(() => {
                moCollection = moSearcher.Get();
                mre.Set();
              };
              thread1.Start();
              ok = mre.WaitOne(5000); // wait 5 seconds
            } else {
              Console.WriteLine("ManagementObjectSearcher failed");
            }
          } else {
            Console.WriteLine("ObjectQuery failed");
          }
        } else {
          Console.WriteLine("ManagementScope failed");
        }
      } else {
        Console.WriteLine("ConnectionOptions failed");
      }
    }
