        private List<SerialPort> openPorts = new List<SerialPort>();
        private void button3_Click(object sender, EventArgs e)
        {
            int baudRate = 9600;
            string testMessage = "test";
            txtPortName.Text = "Testing all serial ports";
            foreach (string s in SerialPort.GetPortNames())
            {
                SerialPort newPort = new SerialPort(s, baudRate, Parity.None, 8, StopBits.One);
                if (!newPort.IsOpen)
                {
                    try
                    {
                        newPort.Open();
                    }
                    catch { }
                }
                if (newPort.IsOpen)
                {
                    openPorts.Add(newPort);
                    newPort.Write(testMessage);
                    newPort.DataReceived += new SerialDataReceivedEventHandler(serialOneOfMany_DataReceived);
                }
                else
                {
                    newPort.Dispose();
                }
            }
            txtPortName.Text = "Waiting for response";
            tmrPortTest.Enabled = true;
        }
        private void serialOneOfMany_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            txtPortName.Text = ((SerialPort)sender).PortName;
        }
        private void tmrPortTest_Tick(object sender, EventArgs e)
        {
            tmrPortTest.Enabled = false;
            foreach (SerialPort port in openPorts)
            {
                if (port.PortName != txtPortName.Text)
                {
                    port.Close();
                    port.Dispose();
                }
            }
        }
