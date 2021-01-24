       using System;
       using System.Text;
       using System.Threading.Tasks;
       using Microsoft.Azure.Devices.Client;
       using Newtonsoft.Json;
       namespace SimulatedDevice
       {
       class Program
        {
        private const string IotHubUri = "YourHubName.azure-devices.net";
        private const string DeviceKey = "Secret Key";
        private const string DeviceId = "DeviceId";
        private const double MinVoltage = 40;
        private const double MinTemperature = 10;
        private const double MinHumidity = 50;
        private static readonly Random Rand = new Random();
        private static DeviceClient _deviceClient;
        private static int _messageId = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Simulated device\n");
            _deviceClient = DeviceClient.Create(IotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(DeviceId, DeviceKey), TransportType.Mqtt);
            _deviceClient.ProductInfo = "Simulated_Client";
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }
        private static async void SendDeviceToCloudMessagesAsync()
        {
            while (true)
            {
                var currentVoltage = MinVoltage + Rand.NextDouble() * 15;
                var currentTemperature = MinTemperature + Rand.NextDouble() * 20;
                var currentHumidity = MinHumidity + Rand.NextDouble() * 25;
                var telemetryDataPoint = new
                {
                   
                    deviceId = DeviceId,
                    timestamp = DateTime.UtcNow,
                    Temperature = currentTemperature,
                    Humidity = currentHumidity,
                    Voltage = currentVoltage,
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));
              
                await _deviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, 
                 messageString);
                await Task.Delay(2000);
              }
             }
          }
         }
