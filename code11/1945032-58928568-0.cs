    public class FtdiDevice
    {
        public string ComPortName { get; set; }
    }
    public class usbState
    {
        public static List<FtdiDevice> existingFtdiPorts = new List<FtdiDevice>();
        public static List<string> allComPorts = new List<string>();
        public event EventHandler<MyEventArgs> DeviceAttached;
        public event EventHandler<MyEventArgs> DeviceRemoved;
        
        public usbState()
        {
        }
        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            string[] updatedAddedComPorts = SerialPort.GetPortNames();
            string[] result = updatedAddedComPorts.Except(allComPorts).ToArray();
            allComPorts.Add(result[0]);
            ManagementObjectCollection ManObjReturn;
            ManagementObjectSearcher ManObjSearch;
            ManObjSearch = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            ManObjReturn = ManObjSearch.Get();
            foreach (ManagementObject ManObj in ManObjReturn)
            {
                int s = ManObj.Properties.Count;
                string name = ManObj["Name"].ToString();
                string man = ManObj["Manufacturer"].ToString();
                if (string.Equals(man, "FTDI") && name.Contains(result[0]))
                {
                    existingFtdiPorts.Add(new FtdiDevice() { ComPortName = result[0] });
                    DeviceAttached(this, new MyEventArgs() { ComPort = result[0] });
                    break;
                }
            }
                
        }
        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            string[] updatedRemovedComPorts = SerialPort.GetPortNames();
            string[] result = allComPorts.Except(updatedRemovedComPorts).ToArray();
            allComPorts.Remove(result[0]);
            var item = existingFtdiPorts.Find(x => x.ComPortName == result[0]);
            if (item != null)
            {
                existingFtdiPorts.Remove(item);
                DeviceRemoved(this, new MyEventArgs() { ComPort = result[0] });
            }
        }
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            insertWatcher.Start();
            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();
            // Do something while waiting for events
            System.Threading.Thread.Sleep(20000000);
        }
    }
    class Program
    {
        static void NewDeviceAdded(object source, MyEventArgs e)
        {
            Console.WriteLine("New Device Attached at Port : " + e.ComPort);
        }
        static void DeviceRemoved(object source, MyEventArgs e)
        {
            Console.WriteLine("Device Removed at Port : " + e.ComPort);
        }
        static void Main(string[] args)
        {
            usbState.allComPorts = SerialPort.GetPortNames().ToList();
            usbState usb = new usbState();
            usb.DeviceAttached += NewDeviceAdded;
            usb.DeviceRemoved += DeviceRemoved;
            ManagementObjectCollection ManObjReturn;
            ManagementObjectSearcher ManObjSearch;
            ManObjSearch = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            ManObjReturn = ManObjSearch.Get();
            foreach (ManagementObject ManObj in ManObjReturn)
            {
                for(int x = 0; x < usbState.allComPorts.Count; x++)
                {
                    string name = ManObj["Name"].ToString();
                    string man = ManObj["Manufacturer"].ToString();
                    if (string.Equals(man, "FTDI") && name.Contains(usbState.allComPorts[x]))
                    {
                        usbState.existingFtdiPorts.Add(new FtdiDevice() { ComPortName = usbState.allComPorts[x] });
                        break;
                    }
                } 
            }
            BackgroundWorker bgwDriveDetector = new BackgroundWorker();
            bgwDriveDetector.DoWork += usb.backgroundWorker1_DoWork;
            bgwDriveDetector.RunWorkerAsync();
            bgwDriveDetector.WorkerReportsProgress = true;
            bgwDriveDetector.WorkerSupportsCancellation = true;
            // System.Threading.Thread.Sleep(100000);
            Console.ReadKey();
        }
    }
