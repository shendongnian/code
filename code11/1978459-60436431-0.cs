    using iMobileDevice;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using LibUsbDotNet.DeviceNotify;
    using System.Windows.Forms;
    
    namespace MobileDeviceDemo
    {
        class Program
        {
            public static IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
            static void Main(string[] args)
            {
    
                //// Hook the device notifier event
                UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
    
                ////NativeLibraries.Load();
    
    
    
                // Exit on and key pressed.
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Waiting for USB Devices connection");
                Console.Write("[Press any key to exit]");
    
                while (!Console.KeyAvailable)
                    Application.DoEvents();
    
                UsbDeviceNotifier.Enabled = false;  // Disable the device notifier
    
                // Unhook the device notifier event
                UsbDeviceNotifier.OnDeviceNotify -= OnDeviceNotifyEvent;
                //GenerateUDIDs();
                //Console.ReadLine();
    
    
            }
    
            private static void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
            {
                if (e.EventType.ToString() == "DeviceArrival")
                {
                    Console.WriteLine("\n Device Connected");
    
                    GenerateUDIDs();
                }
                
            }
    
            private static void GenerateUDIDs()
            {
                NativeLibraries.Load();
    
                ReadOnlyCollection<string> udids;
                int count = 0;
    
                var idevice = LibiMobileDevice.Instance.iDevice;
                var lockdown = LibiMobileDevice.Instance.Lockdown;
    
                var ret = idevice.idevice_get_device_list(out udids, ref count);
    
                if (ret == iDeviceError.NoDevice)
                {
                    // Not actually an error in our case
                    Console.WriteLine("No devices found");
                    return;
                }
    
                ret.ThrowOnError();
    
                int NumberOfDeviceConnected = udids.Count;
                Console.WriteLine($"\n Number of Devices Connected: {NumberOfDeviceConnected}");
    
                int ctr = 0;
                // Get the device name
                foreach (var udid in udids)
                {
                    ctr++;
                    iDeviceHandle deviceHandle;
                    idevice.idevice_new(out deviceHandle, udid).ThrowOnError();
    
                    LockdownClientHandle lockdownHandle;
                    lockdown.lockdownd_client_new_with_handshake(deviceHandle, out lockdownHandle, "Quamotion").ThrowOnError();
    
                    string deviceName;
                    lockdown.lockdownd_get_device_name(lockdownHandle, out deviceName).ThrowOnError();
    
                    string sn;
                    iMobileDevice.Plist.PlistHandle tested1;
                    lockdown.lockdownd_get_value(lockdownHandle, null, "SerialNumber", out tested1).ThrowOnError();
    
                    //Get string values from plist
                    tested1.Api.Plist.plist_get_string_val(tested1, out sn);
    
                    
                    Console.WriteLine($"\n device: {ctr} Name: {deviceName}  UDID: {udid}  Serial Number: {sn}");
    
                    deviceHandle.Dispose();
                    lockdownHandle.Dispose();
                }
            }
        }
    }
