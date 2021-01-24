    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Diagnostics.Tracing;
    using Microsoft.Azure.Devices.Client;
    
    namespace Device2CloudApp
    {
        class Program
        {
            // private our own fields for connection to IOT.
            private DeviceClient deviceClient;    
            // use the device specific connection string.
    
            private const string IOT_HUB_CONN_STRING = "HostName=eNstaHub.azure-devices.net;DeviceId=GcobaniNumber1;SharedAccessKey="";
            private const string IOT_HUB_DEVICE = "GcobaniNumber1";
            private const string IOT_HUB_DEVICE_LOCATION = "West US";
    
    
            /*
             *  We calling all method inside the constructor for memory allocation. 
             */
            public  Program ()
            {
                DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(IOT_HUB_CONN_STRING);
                SendMessageToIOTHubAsync(deviceClient).Wait();
    
            }
    
            private async Task SendMessageToIOTHubAsync(DeviceClient deviceClient)
            {
                try
                {
                    var payload = "{" +
                    "\"deviceId\":\"" + IOT_HUB_DEVICE + "\", " +
                    "\"location\":\"" + IOT_HUB_DEVICE_LOCATION + "\", " +
                    "\"localTimestamp\":\"" + DateTime.Now.ToLocalTime() + "\"" +
                    "}";
    
                    var msg = new Message(Encoding.UTF8.GetBytes(payload));
                    System.Diagnostics.Debug.WriteLine("\t{0} > Sending message:[{1}]", DateTime.Now.ToLocalTime(), payload);
                    await deviceClient.SendEventAsync(msg);
                }catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("!!!" + ex.Message);
                }
            }
    
    
            static void Main(string[] args)
            {
                // creating a Constructor here for method declarion.
    
                Program prg = new Program(deviceClient);
            }
        }
    }
