    private void OnDataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            var serialDevice = sender as SerialPort;
            var indata = serialDevice.ReadExisting();
            int DigitFromArduino = 0;
            if(int.TryParse(indata,out DigitFromArduino))
                if(DigitFromArduino == 1)
                {
                    // call your function to increase the volum
                }
        }
