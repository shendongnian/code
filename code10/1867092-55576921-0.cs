    using System;
    using System.Data;
    using NeuroSky.ThinkGear;
    namespace MindWave_Reader
    {
      class ReadEEG
      {
        public double AlphaValue { get; set; }
        private Connector connector;
    
        public ReadEEG()
        {
          // Initialize a new Connector and add event handlers
          connector = new Connector();
          connector.DeviceConnected += new EventHandler(OnDeviceConnected);
    
          // Scan for headset on COM7 port
          connector.ConnectScan("COM7");
        }
        
        // Called when a device is connected
        public void OnDeviceConnected(object sender, EventArgs e)
        {
          Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;
    
          Console.WriteLine("Device found on: " + de.Device.PortName);
          de.Device.DataReceived += new EventHandler(OnDataReceived);
        }
        
        // Called when data is received from a device
        public void OnDataReceived(object sender, EventArgs e)
        {
          Device.DataEventArgs de = (Device.DataEventArgs)e;
          DataRow[] tempDataRowArray = de.DataRowArray;
    
          TGParser tgParser = new TGParser();
          tgParser.Read(de.DataRowArray);
    
          /* Loops through the newly parsed data of the connected headset */
          for (int i = 0; i < tgParser.ParsedData.Length; i++)
          {
            if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha"))
            {
              AlphaValue = tgParser.ParsedData[i]["EegPowerAlpha"];
              Console.WriteLine("Alpha: " + AlphaValue);
              // Raise the AlphaReceived event with the new reading.
              OnAlphaReceived(new AlphaReceivedEventArgs() { Alpha = AlphaValue });
            }
          }
        }
    
        /// <summary>
        /// The arguments for the <see cref="AlphaReceived"/> event.
        /// </summary>
        public class AlphaReceivedEventArgs : EventArgs
        {
          /// <summary>
          /// The alpha value that was just received.
          /// </summary>
          public double Alpha { get; set; }
        }
    
        /// <summary>
        /// Raises the <see cref="AlphaReceived"/> event if there is a subscriber.
        /// </summary>
        /// <param name="e">Contains the new alpha value.</param>
        protected virtual void OnAlphaReceived(AlphaReceivedEventArgs e)
        {
          AlphaReceived?.Invoke(this, e);
        }
    
        /// <summary>
        /// Event that gets raised whenever a new AlphaValue is received from the
        /// device.
        /// </summary>
        public event EventHandler AlphaReceived;
      }
    }
