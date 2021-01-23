    private void port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      Thread.Sleep(1);
      byte DATA = Convert.ToByte(serialPort1.ReadByte());
      String data=Convert.ToString(DATA);
       
      if (textBox1.InvokeRequired)
       {
         textBox1.Invoke(new Action(() => { textBox1.Text = data; }));
       }
    }
