     public void GetCompDet(string ComputerName)
            {
                CurrentSystem = ComputerName;
                ConnectionOptions options = new ConnectionOptions();
                
    
                ManagementScope moScope = new ManagementScope(@"\\" + ComputerName + @"\root\cimv2");
                try
                {
                    moScope.Connect();
                }
                catch
                {
                    return;
                }
                ObjectQuery query = new ObjectQuery("select * from Win32_Process where name='explorer.exe'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(moScope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    ManagementOperationObserver mo = new ManagementOperationObserver();
                    mo.ObjectReady += new ObjectReadyEventHandler(mo_ObjectReady);
                    m.InvokeMethod(mo, "GetOwner", null);
                }
    
    
            }
    
            void mo_ObjectReady(object sender, ObjectReadyEventArgs e)
            {
                ManagementObject m = sender as ManagementObject;
                LoggedinUser.Enqueue(CurrentSystem + " - >" + e.NewObject.Properties["user"].Value.ToString());
                Console.WriteLine(CurrentSystem + " - >" + e.NewObject.Properties["user"].Value.ToString());
            }
