    // ...   
    private void button1_Click(object sender, System.EventArgs e)
    {
        SendByte(1); // Send byte '1' to the Arduino
    }
    private void SendByte(int byteToSend) {
        byte[] bytes = new byte[] { (byte) byteToSend };
        serialPort1.Write(bytes, 0, bytes.Length);
    }
    // ...
