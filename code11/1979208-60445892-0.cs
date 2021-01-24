    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        // Perform any additional setup after loading the view, typically from a nib.
        myDel = new MySimpleCBCentralManagerDelegate();
        var myMgr = new CBCentralManager(myDel, DispatchQueue.CurrentQueue);
    }
    public class MySimpleCBCentralManagerDelegate : CBCentralManagerDelegate
    {
        override public void UpdatedState(CBCentralManager mgr)
        {
            if (mgr.State == CBCentralManagerState.PoweredOn)
            {
                Console.WriteLine("Consider turning Bluetooth off if not in use or check to see if all connected devices are recognisable");
                //Passing in null scans for all peripherals. Peripherals can be targeted by using CBUIIDs
                CBUUID[] cbuuids = null;
                mgr.ScanForPeripherals(cbuuids); //Initiates async calls of DiscoveredPeripheral
                                                    //Timeout after 30 seconds
                var timer = new Timer(30 * 1000);
                timer.Elapsed += (sender, e) => mgr.StopScan();
            }
            else
            {
                //Invalid state -- Bluetooth powered down, unavailable, etc.
                System.Console.WriteLine("Bluetooth is not available");
            }
        }
        public override void DiscoveredPeripheral(CBCentralManager central, CBPeripheral peripheral, NSDictionary advertisementData, NSNumber RSSI)
        {
            Console.WriteLine("Discovered {0}, data {1}, RSSI {2}", peripheral.Name, advertisementData, RSSI);
        }
    }
