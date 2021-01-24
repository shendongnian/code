        private void setup()
        {
            System.Diagnostics.Debug.WriteLine("Initialize MTPNordic");
            nRf24.InitNordicSPI(new SpiConnectionSettings(0), 3000000, 12, 13);
            nRf24.OnDataReceived += new nRF24L01P.OnDataReceivedEventHandler(nRf24_OnDataReceived);
            RFConfiguration();
        }
