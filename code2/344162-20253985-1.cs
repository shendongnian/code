    try
            {
                if ((m_SerialPort != null))
                {
                    if (m_SerialPort.IsOpen)
                    {
                        m_SerialPort.Close();
                    }
                 }
                 m_SerialPort = new SerialPort(portName, dataRate, parity, databits, stopBits.One);
                 m_SerialPort.Open();
                 if (!m_SerialPort.IsOpen)
                 {
                     MessageBox.Show(string.Concat(portName, " failed to open"));
                 }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
