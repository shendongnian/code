        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (serialPort1.BytesToRead > 0)
                {
                    DataIn = serialPort1.ReadLine();
                    this.Invoke(new EventHandler(MostraDados));
                }
            }
            catch (Exception ex)
            { }
        }
