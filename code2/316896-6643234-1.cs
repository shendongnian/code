        static void usbDeviceChanged_Async()
        {
            try
            {
                WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent");
                ManagementEventWatcher watcher =
                    new ManagementEventWatcher(query);
                watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
                watcher.Start();
                Console.ReadLine();
                watcher.Stop();
            }
            catch (ManagementException err) { }
        }
        static void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject eventObj = (ManagementBaseObject)e.NewEvent;
            Console.WriteLine("Qualifiers");
            foreach (QualifierData q in eventObj.Qualifiers)
            {
                Console.WriteLine(q.Name + ": " + q.Value);
            }
            Console.WriteLine("Properties");
            foreach (PropertyData p in eventObj.Properties)
            {
                Console.WriteLine(p.Name + ": " + p.Value);
            }           
        }
