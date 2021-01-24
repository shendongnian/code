    using InTheHand.Net;
    using InTheHand.Net.Bluetooth;
    using InTheHand.Net.Bluetooth.AttributeIds;
    using InTheHand.Net.Sockets;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace BluetoothPrototype1
    {
        class Program
        {
            private const string DEVICE_NAME = "G3";
    
            private static BluetoothDeviceInfo _device = null;
            private static BluetoothWin32Events _bluetoothEvents = null;
    
            static void Main(string[] args)
            {
                try
                {
                    displayBluetoothRadio();
    
                    _bluetoothEvents = BluetoothWin32Events.GetInstance();
                    _bluetoothEvents.InRange += onInRange;
                    _bluetoothEvents.OutOfRange += onOutOfRange;
    
                    using (BluetoothClient client = new BluetoothClient())
                    {
                        BluetoothComponent component = new BluetoothComponent(client);
                        component.DiscoverDevicesProgress += onDiscoverDevicesProgress;
                        component.DiscoverDevicesComplete += onDiscoverDevicesComplete;
                        component.DiscoverDevicesAsync(255, true, false, false, false, null);
    
                        //BluetoothDeviceInfo[] peers = client.DiscoverDevices();
    
                        //device = peers.ToList().Where(p => p.DeviceName == DEVICE_NAME).FirstOrDefault();
                    }                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.ReadKey();
                }
            }
    
            static void onOutOfRange(object sender, BluetoothWin32RadioOutOfRangeEventArgs e)
            {
                Console.WriteLine(string.Format("Device {0} out of range", e.Device.DeviceName));
            }
    
            static void onInRange(object sender, BluetoothWin32RadioInRangeEventArgs e)
            {
                Console.WriteLine(string.Format("Device {0} in range.  Connected:{1}", e.Device.DeviceName, e.Device.Connected));
            }
    
            static void onDiscoverDevicesProgress(object sender, DiscoverDevicesEventArgs e)
            {
                Console.WriteLine("Device discovery in progress");
                foreach (var device in e.Devices)
                {
                    Console.WriteLine(device.DeviceName);
                }
                Console.WriteLine();
            }
    
            static void onDiscoverDevicesComplete(object sender, DiscoverDevicesEventArgs e)
            {
                Console.WriteLine("Device discovery complete");
                foreach (var device in e.Devices)
                {
                    Console.WriteLine(device.DeviceName);
                }
                Console.WriteLine();
    
                _device = e.Devices.ToList().Where(p => p.DeviceName == DEVICE_NAME).FirstOrDefault();
    
                if (_device != null)
                {                
                    Console.WriteLine("Selected {0} device with address {1}", _device.DeviceName, _device.DeviceAddress);               
    
                    using (BluetoothClient client = new BluetoothClient())
                    {
                        client.Connect(new BluetoothEndPoint(_device.DeviceAddress, BluetoothService.SerialPort));
                        Stream peerStream = client.GetStream();
    
                        for (int i = 0; i < 100; i++)
                        {
                            byte[] wb = Encoding.ASCII.GetBytes(string.Format("{0:X2} : This is a test : {1}{2}", i, DateTime.Now.ToString("o"), Environment.NewLine));
                            peerStream.Write(wb, 0, wb.Length);
                        }
    
                        byte [] buf = new byte[1024];
                        int readLength = peerStream.Read(buf, 0, buf.Length);
                        if (readLength > 0)
                        {
                            Console.WriteLine("Received {0} bytes", readLength);
                        }
                        else
                        {
                            Console.WriteLine("Connection is closed");
                        }
                    }
                }
            }
    
            private static void displayBluetoothRadio()
            {
                BluetoothRadio myRadio = BluetoothRadio.PrimaryRadio;
                if (myRadio == null)
                {
                    Console.WriteLine("No radio hardware or unsupported software stack");
                    return;
                }
                RadioMode mode = myRadio.Mode;
                // Warning: LocalAddress is null if the radio is powered-off.
                Console.WriteLine("* Radio, address: {0:C}", myRadio.LocalAddress);
                Console.WriteLine("Mode: " + mode.ToString());
                Console.WriteLine("Name: " + myRadio.Name);
                Console.WriteLine("HCI Version: " + myRadio.HciVersion
                    + ", Revision: " + myRadio.HciRevision);
                Console.WriteLine("LMP Version: " + myRadio.LmpVersion
                    + ", Subversion: " + myRadio.LmpSubversion);
                Console.WriteLine("ClassOfDevice: " + myRadio.ClassOfDevice.ToString()
                    + ", device: " + myRadio.ClassOfDevice.Device.ToString()
                    + " / service: " + myRadio.ClassOfDevice.Service.ToString());
                //
                //
                // Enable discoverable mode
                Console.WriteLine();
                myRadio.Mode = RadioMode.Discoverable;
                Console.WriteLine("Radio Mode now: " + myRadio.Mode.ToString());
                Console.WriteLine();
            }
        }
    }
